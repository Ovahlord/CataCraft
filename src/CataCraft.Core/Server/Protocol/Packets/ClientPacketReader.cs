// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Text;
using CataCraft.Core.Game.World.Entities.Object;

namespace CataCraft.Core.Server.Protocol.Packets;

public ref struct ClientPacketReader
{
    public long UnreadBytes => _reader.Remaining;

    private const string ExceptionMessage = "Tried to read more data from the payload than received";
    private SequenceReader<byte> _reader;
    private byte _bitPosition = 8;
    private byte _currentBitValue = 0;

    public ClientPacketReader(in ReadOnlySequence<byte> payload)
    {
        _reader = new(payload);
    }

    public byte ReadUInt8()
    {
        if (_reader.TryRead(out byte value))
            return value;

        throw new IOException(ExceptionMessage);
    }

    public sbyte ReadInt8() => (sbyte)ReadUInt8();

    public short ReadInt16()
    {
        if (_reader.TryReadLittleEndian(out short value))
            return value;

        throw new IOException(ExceptionMessage);
    }

    public ushort ReadUInt16() => (ushort)ReadInt16();

    public int ReadInt32()
    {
        if (_reader.TryReadLittleEndian(out int value))
            return value;

        throw new IOException(ExceptionMessage);
    }

    public uint ReadUInt32() => (uint)ReadInt32();

    public long ReadInt64()
    {
        if (_reader.TryReadLittleEndian(out long value))
            return value;

        throw new IOException(ExceptionMessage);
    }

    public ulong ReadUInt64() => (ulong)ReadInt64();

    public float ReadSingle()
    {
        if (_reader.TryReadLittleEndian(out int intValue))
            return BitConverter.Int32BitsToSingle(intValue);

        throw new IOException(ExceptionMessage);
    }

    public double ReadDouble()
    {
        if (_reader.TryReadLittleEndian(out long longValue))
            return BitConverter.Int64BitsToDouble(longValue);

        throw new IOException(ExceptionMessage);
    }

    public string ReadString(int length, Encoding? encoding = null)
    {
        if (_reader.TryReadExact(length, out var value))
            return (encoding ?? Encoding.UTF8).GetString(value);

        throw new IOException(ExceptionMessage);
    }

    public string ReadCString(Encoding? encoding = null)
    {
        if (_reader.TryReadTo(out ReadOnlySequence<byte> value, 0))
            return (encoding ?? Encoding.UTF8).GetString(value);

        throw new IOException(ExceptionMessage);
    }

    public byte[] ReadBytes(int length)
    {
        if (length == 0)
            return [];

        if (_reader.TryReadExact(length, out ReadOnlySequence<byte> value))
            return value.ToArray();

        throw new IOException(ExceptionMessage);
    }

    public string ReadFourCCString()
    {
        if (_reader.TryReadBigEndian(out int fourCCValue))
            return Encoding.UTF8.GetString(BitConverter.GetBytes(fourCCValue));

        throw new IOException(ExceptionMessage);
    }

    public bool ReadBool() => ReadUInt8() != 0;

    public DateTimeOffset ReadTime() => DateTimeOffset.FromUnixTimeSeconds(ReadUInt32());

    // Bit reading methods
    public byte ReadBit()
    {
        ++_bitPosition;
        if (_bitPosition > 7)
        {
            _bitPosition = 0;
            _currentBitValue = ReadUInt8();
        }

        return (byte)(_currentBitValue >> 7 - _bitPosition & 1);
    }

    public uint ReadBits(int bits)
    {
        uint value = 0;
        for (int i = bits - 1; i >= 0; --i)
        {
            if (ReadBit() != 0)
                value |= (uint)(1 << i);
        }

        return value;
    }

    public byte[] StartBitStream(params byte[] values)
    {
        byte[] bytes = new byte[values.Length];

        foreach (byte value in values)
        {
            bytes[value] = (byte)(ReadBit() != 0 ? 1 : 0);
        }

        return bytes;
    }

    public byte[] ParseBitStream(Span<byte> stream, params byte[] values)
    {
        var tempBytes = new byte[values.Length];
        var i = 0;

        foreach (byte value in values)
        {
            if (stream[value] != 0)
                stream[value] ^= ReadUInt8();

            tempBytes[i++] = stream[value];
        }

        return tempBytes;
    }

    public void ReadByteSeq(ref WowGuid b, byte index)
    {
        if (b[index] != 0)
            b[index] ^= ReadUInt8();
    }

}
