// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Buffers.Binary;
using System.Reflection;
using System.Text;
using CataCraft.DBC.Attributes;

namespace CataCraft.DBC;

public static class WDB2Reader
{
    private const int HeaderSize = 48;
    public const uint WDB2Signature = 0x32424457; // WDB2

    public static async Task ReadStorageAsync<T>(Stream stream, IDictionary<int, T> storage, CancellationToken token = default) where T : new()
    {
        // Reset the stream back to its beginning
        stream.Seek(0, SeekOrigin.Begin);

        if (stream.Length < HeaderSize)
            throw new InvalidDataException("Invalid header size for storage.");

        using BinaryReader reader = new(stream);
        uint magic = reader.ReadUInt32();

        if (magic != WDB2Signature)
            throw new InvalidDataException("Invalid WDB2 signature.");

        int recordCount = reader.ReadInt32();
        /*int fieldCount =*/ reader.ReadInt32();
        int recordSize = reader.ReadInt32();
        int stringBlockSize = reader.ReadInt32();
        /*int tableHash*/ reader.ReadInt32();
        /*int build*/ reader.ReadInt32();
        /*int timestamp*/ reader.ReadUInt32();
        int minId = reader.ReadInt32();
        int maxId = reader.ReadInt32();
        /*int locale*/ reader.ReadInt32();
        /*int copyTableSize*/  reader.ReadInt32();

        if (recordCount == 0)
            return;

        if (maxId > 0)
        {
            stream.Position += (maxId - minId + 1) * sizeof(int); // skipping over indices
            stream.Position += (maxId - minId + 1) * sizeof(short); // skipping over string lengths
        }

        byte[] recordBuffer = ArrayPool<byte>.Shared.Rent(recordSize * recordCount);
        byte[] stringBlockBuffer = ArrayPool<byte>.Shared.Rent(stringBlockSize);

        try
        {
            await stream.ReadExactlyAsync(recordBuffer, 0, recordSize * recordCount, token);
            await stream.ReadExactlyAsync(stringBlockBuffer, 0, stringBlockSize, token);

            ReadOnlyMemory<byte> recordData = recordBuffer.AsMemory(0, recordSize * recordCount);
            ReadOnlyMemory<byte> stringBlockData = stringBlockBuffer.AsMemory(0, stringBlockSize);

            // Parse the records
            await ParseRecordsAsync(storage, recordData, stringBlockData, recordCount, recordSize, token);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(recordBuffer);
            ArrayPool<byte>.Shared.Return(stringBlockBuffer);
        }
    }

    private static async Task ParseRecordsAsync<T>(IDictionary<int, T> storage, ReadOnlyMemory<byte> recordData, ReadOnlyMemory<byte> stringBlockData, int recordCount, int recordSize, CancellationToken token = default) where T : new()
    {
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
            ReadOnlySpan<byte> rawRecord = recordData.Span.Slice(i * recordSize, recordSize);

            T record = new();
            int index = DeserializeRecord(record, rawRecord, stringBlockData.Span, fields, indexField, cardinalities);
            lock (storage)
                storage.Add(index, record);
        });
    }

    private static int DeserializeRecord<T>(T record, ReadOnlySpan<byte> rawRecord, ReadOnlySpan<byte> stringBlockData, FieldInfo[] fields, FieldInfo? indexField, int[] cardinalities)
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
                    object? arrayFieldValue = ReadFieldValue(rawRecord, stringBlockData, ref position, elementType);
                    dataArray.SetValue(arrayFieldValue, x);
                }

                continue;
            }

            // Regular field parsing
            object? fieldValue =  ReadFieldValue(rawRecord, stringBlockData, ref position, field.FieldType);
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

    private static object? ReadFieldValue(ReadOnlySpan<byte> rawRecord, ReadOnlySpan<byte> stringBlockData, ref int position, Type fieldType)
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
            int stringBlockPosition = BinaryPrimitives.ReadInt32LittleEndian(rawRecord.Slice(position, sizeof(int)));
            position += sizeof(int);

            ReadOnlySpan<byte> stringSegment = stringBlockData.Slice(stringBlockPosition);
            int nullTerminatorIndex = stringSegment.IndexOf((byte)0);
            if (nullTerminatorIndex != -1)
                return Encoding.UTF8.GetString(stringSegment.Slice(0, nullTerminatorIndex));

            return Encoding.UTF8.GetString(stringSegment);
        }

        return null;
    }
}
