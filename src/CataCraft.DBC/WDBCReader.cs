// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Buffers.Binary;
using System.Reflection;
using System.Text;
using CataCraft.DBC.Attributes;

namespace CataCraft.DBC;

public static class WDBCReader
{
    private const int HeaderSize = 20;
    private const uint WDBCSignature = 0x43424457; // WDBC

    public static async Task ReadStorageAsync<T>(Stream stream, IDictionary<int, T> storage, CancellationToken token = default) where T : new()
    {
        // Reset the stream back to its beginning
        stream.Seek(0, SeekOrigin.Begin);

        if (stream.Length < HeaderSize)
            throw new InvalidDataException("Invalid header size for storage.");

        using BinaryReader reader = new(stream);
        uint magic = reader.ReadUInt32();

        if (magic != WDBCSignature)
            throw new InvalidDataException("Invalid WDBC signature.");

        int recordCount = reader.ReadInt32();
        /*int fieldCount =*/ reader.ReadInt32();
        int recordSize = reader.ReadInt32();
        int stringTableSize = reader.ReadInt32();

        if (recordCount == 0)
            return;

        // Parse the string table first
        Dictionary<int, string> stringTable = new(stringTableSize / 0x20);
        if (stringTableSize > 0)
        {
            long position = stream.Position;
            stream.Position += recordCount * recordSize;
            await ParseStringTableAsync(stream, stringTable, stringTableSize, token);
            stream.Position = position;
        }

        // Parse the records
        await ParseRecordsAsync(stream, storage, stringTable, recordCount, recordSize, token);
    }

    private static async Task ParseStringTableAsync(Stream stream, Dictionary<int, string> stringTable, int stringBlockSize, CancellationToken token = default)
    {
        byte[] stringTableBuffer = ArrayPool<byte>.Shared.Rent(stringBlockSize);
        try
        {
            await stream.ReadExactlyAsync(stringTableBuffer, 0, stringBlockSize, token);

            int position = 0;
            Span<byte> data = stringTableBuffer.AsSpan(0, stringBlockSize);

            while (position < data.Length)
            {
                int index = data.Slice(position).IndexOf((byte)0);
                if (index != -1) // Found a null terminator
                {
                    stringTable.Add(position, Encoding.UTF8.GetString(data.Slice(position, index)));
                    position += index + 1;
                }
                else // No further null terminators found - parse the remaining data as string
                {
                    stringTable.Add(position, Encoding.UTF8.GetString(data.Slice(position)));
                    break;
                }
            }

        }
        finally
        {
            ArrayPool<byte>.Shared.Return(stringTableBuffer);
        }
    }

    private static async Task ParseRecordsAsync<T>(Stream stream, IDictionary<int, T> storage, Dictionary<int, string> stringTable, int recordCount, int recordSize, CancellationToken token = default) where T : new()
    {
        byte[] recordBuffer = ArrayPool<byte>.Shared.Rent(recordCount * recordSize);
        try
        {
            // Read the raw record data first and slice it into record sized pieces
            await stream.ReadExactlyAsync(recordBuffer, 0, recordSize * recordCount, token);

            // Slice the memory into single record pieces
            ReadOnlyMemory<byte> data = recordBuffer.AsMemory(0, recordSize * recordCount);

            // Extract the properties
            FieldInfo[] fields = typeof(T).GetFields();
            FieldInfo? indexField = fields.FirstOrDefault(p => p.GetCustomAttribute<IndexAttribute>() != null);
            if (indexField == null)
                throw new InvalidDataException($"The Record type {typeof(T).Name} doesn't have any index specified");

            int[] cardinalities = new int[fields.Length];
            for (int i = 0; i < fields.Length; i++)
                cardinalities[i] = fields[i].GetCustomAttribute<CardinalityAttribute>()?.Count ?? 0;

            // Parse the records into our data structure
            Parallel.For(0, recordCount, i =>
            {
                ReadOnlySpan<byte> dataSpan = data.Span.Slice(i * recordSize, recordSize);

                T record = new();
                int index = DeserializeRecord(record, dataSpan, fields, indexField, cardinalities, stringTable);
                lock (storage)
                    storage.Add(index, record);
            });
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(recordBuffer);
        }
    }

    private static int DeserializeRecord<T>(T record, ReadOnlySpan<byte> rawRecord, FieldInfo[] fields, FieldInfo? indexField, int[] cardinalities, Dictionary<int, string> stringTable)
    {
        int position = 0;
        int index = 0;

        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];

            // Array parsing
            if (field.FieldType.IsArray)
            {
                if (cardinalities[i] <= 0)
                    throw new InvalidDataException($"The cardinality {cardinalities[i]} for property {field.Name} is too small");

                Type? elementType = field.FieldType.GetElementType();
                if (elementType == null)
                    throw new InvalidDataException("Unknown element type??");

                Array dataArray = Array.CreateInstance(elementType, cardinalities[i]);
                for (int x = 0; x < dataArray.Length; ++x)
                {
                    object? arrayFieldValue = ReadFieldValue(rawRecord, ref position, elementType, stringTable);
                    dataArray.SetValue(arrayFieldValue, x);
                }

                continue;
            }

            // Regular field parsing
            object? fieldValue =  ReadFieldValue(rawRecord, ref position, field.FieldType, stringTable);
            field.SetValue(record, fieldValue);

            if (field == indexField)
            {
                if (fieldValue is int intValue)
                    index = intValue;
                else
                    index = Convert.ToInt32(fieldValue);
            }
        }

        return index;
    }

    private static object? ReadFieldValue(ReadOnlySpan<byte> rawRecord, ref int position, Type fieldType, Dictionary<int, string> stringTable)
    {
        if (fieldType == typeof(byte))
        {
            byte value = rawRecord.Slice(position, 1)[0];
            position += sizeof(byte);
            return value;
        }

        if (fieldType == typeof(sbyte))
        {
            sbyte value = (sbyte)rawRecord.Slice(position, 1)[0];
            position += sizeof(sbyte);
            return value;
        }

        if (fieldType == typeof(short))
        {
            short value = BinaryPrimitives.ReadInt16LittleEndian(rawRecord.Slice(position, sizeof(short)));
            position += sizeof(short);
            return value;
        }

        if (fieldType == typeof(ushort))
        {
            ushort value = BinaryPrimitives.ReadUInt16LittleEndian(rawRecord.Slice(position, sizeof(ushort)));
            position += sizeof(ushort);
            return value;
        }

        if (fieldType == typeof(int))
        {
            int value = BinaryPrimitives.ReadInt32LittleEndian(rawRecord.Slice(position, sizeof(int)));
            position += sizeof(int);
            return value;
        }

        if (fieldType == typeof(uint))
        {
            uint value = BinaryPrimitives.ReadUInt32LittleEndian(rawRecord.Slice(position, sizeof(uint)));
            position += sizeof(uint);
            return value;
        }

        if (fieldType == typeof(long))
        {
            long value = BinaryPrimitives.ReadInt64LittleEndian(rawRecord.Slice(position, sizeof(long)));
            position += sizeof(long);
            return value;
        }

        if (fieldType == typeof(ulong))
        {
            ulong value = BinaryPrimitives.ReadUInt64LittleEndian(rawRecord.Slice(position, sizeof(ulong)));
            position += sizeof(ulong);
            return value;
        }

        if (fieldType == typeof(float))
        {
            float value = BinaryPrimitives.ReadSingleLittleEndian(rawRecord.Slice(position, sizeof(float)));
            position += sizeof(float);
            return value;
        }

        if (fieldType == typeof(double))
        {
            double value = BinaryPrimitives.ReadDoubleLittleEndian(rawRecord.Slice(position, sizeof(double)));
            position += sizeof(double);
            return value;
        }

        if (fieldType == typeof(string))
        {
            // String fields hold an offset into the string table
            int value = BinaryPrimitives.ReadInt32LittleEndian(rawRecord.Slice(position, sizeof(int)));
            position += sizeof(int);
            return stringTable.GetValueOrDefault(value, string.Empty);
        }

        return null;
    }
}
