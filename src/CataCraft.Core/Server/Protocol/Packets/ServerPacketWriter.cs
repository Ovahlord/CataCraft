// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Buffers.Binary;
using System.Text;

namespace CataCraft.Core.Server.Protocol.Packets;

public ref struct ServerPacketWriter
{
    private static readonly ArrayPool<byte> s_bufferPool = ArrayPool<byte>.Shared;
    private const int InitialBufferSize = 1024;

    private byte[] _buffer;
    private int _writtenBytes;
    private byte _bitPosition = 8;
    private byte _currentBitValue = 0;

    public byte[] Buffer => _buffer;
    public int WrittenBytes => _writtenBytes;

    public ServerPacketWriter()
    {
        _buffer = s_bufferPool.Rent(InitialBufferSize);
    }

    public void WriteUInt8(byte value)
    {
        GetSpan(sizeof(byte))[0] = value;
    }

    public void WriteInt8(sbyte value) => WriteUInt8((byte)value);

    public void WriteInt16(short value)
    {
        int size = sizeof(short);
        BinaryPrimitives.WriteInt16LittleEndian(GetSpan(size), value);
    }

    public void WriteUInt16(ushort value)
    {
        int size = sizeof(ushort);
        BinaryPrimitives.WriteUInt16LittleEndian(GetSpan(size), value);
    }

    public void WriteInt32(int value)
    {
        int size = sizeof(int);
        BinaryPrimitives.WriteInt32LittleEndian(GetSpan(size), value);
    }

    public void WriteUInt32(uint value)
    {
        int size = sizeof(uint);
        BinaryPrimitives.WriteUInt32LittleEndian(GetSpan(size), value);
    }

    public void WriteInt64(long value)
    {
        int size = sizeof(long);
        BinaryPrimitives.WriteInt64LittleEndian(GetSpan(size), value);
    }

    public void WriteUInt64(ulong value)
    {
        int size = sizeof(ulong);
        BinaryPrimitives.WriteUInt64LittleEndian(GetSpan(size), value);
    }

    public void WriteFloat(float value)
    {
        int size = sizeof(float);
        BinaryPrimitives.WriteSingleLittleEndian(GetSpan(size), value);
    }

    public void WriteDouble(double value)
    {
        int size = sizeof(double);
        BinaryPrimitives.WriteDoubleLittleEndian(GetSpan(size), value);
    }

    public void WriteCString(string value)
    {
        int size = value.Length + 1;
        Span<byte> buffer = GetSpan(size);
        Encoding.ASCII.GetBytes(value, buffer);

        // Assign null terminator
        buffer[value.Length] = 0;
    }

    public void WriteString(string value)
    {
        Span<byte> buffer = GetSpan(value.Length);
        Encoding.ASCII.GetBytes(value, buffer);
    }

    public void WriteBytes(scoped ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length == 0)
            return;

        int size = bytes.Length;
        bytes.CopyTo(GetSpan(size));
    }

    public void WriteBool(bool value)
    {
        WriteUInt8((byte)(value ? 1 : 0));
    }

    public void FlushBits()
    {
        if (_bitPosition == 0)
            return;

        _bitPosition = 8;
        WriteUInt8(_currentBitValue);
        _currentBitValue = 0;
    }

    public bool WriteBit(bool bit)
    {
        --_bitPosition;
        if (bit)
            _currentBitValue |= (byte)(1 << _bitPosition);

        if (_bitPosition == 0)
        {
            _bitPosition = 8;
            WriteUInt8(_currentBitValue);
            _currentBitValue = 0;
        }

        return bit;
    }

    public bool WriteBit(byte bit) { return WriteBit(bit != 0); }

    public void WriteBits(ulong value, int bits)
    {
        value &= (1UL << bits) - 1;

        if (bits > _bitPosition)
        {
            _currentBitValue |= (byte)(value >> bits - _bitPosition);
            bits -= _bitPosition;
            _bitPosition = 8;
            WriteUInt8(_currentBitValue);

            while (bits >= 8)
            {
                bits -= 8;
                WriteUInt8((byte)(value >> bits));
            }

            _bitPosition = (byte)(8 - bits);
            _currentBitValue = (byte)((value & (1UL << bits) - 1) << _bitPosition);
        }
        else
        {
            _bitPosition -= (byte)bits;
            _currentBitValue |= (byte)(value << _bitPosition);

            if (_bitPosition == 0)
            {
                _bitPosition = 8;
                WriteUInt8(_currentBitValue);
                _currentBitValue = 0;
            }
        }
    }

    public void WriteBits(int value, int bits)
    {
        value &= (1 << bits) - 1;

        if (bits > _bitPosition)
        {
            _currentBitValue |= (byte)(value >> bits - _bitPosition);
            bits -= _bitPosition;
            _bitPosition = 8;
            WriteUInt8(_currentBitValue);

            while (bits >= 8)
            {
                bits -= 8;
                WriteUInt8((byte)(value >> bits));
            }

            _bitPosition = (byte)(8 - bits);
            _currentBitValue = (byte)((value & (1 << bits) - 1) << _bitPosition);
        }
        else
        {
            _bitPosition -= (byte)bits;
            _currentBitValue |= (byte)(value << _bitPosition);

            if (_bitPosition == 0)
            {
                _bitPosition = 8;
                WriteUInt8(_currentBitValue);
                _currentBitValue = 0;
            }
        }
    }

    public void WriteByteSeq(byte b)
    {
        if (b != 0)
            WriteUInt8((byte)(b ^ 1));
    }

    public void WritePackGUID(ulong guid)
    {
        Span<byte> packGuid = stackalloc byte[8 + 1];
        byte size = 1;
        for (byte i = 0; guid != 0; ++i)
        {
            if ((guid & 0xFF) != 0)
            {
                packGuid[0] |= (byte)(1 << i);
                packGuid[size] = (byte)(guid & 0xFF);
                ++size;
            }

            guid >>= 8;
        }

        WriteBytes(packGuid.Slice(0, size));
    }

    public void WriteTime(DateTimeOffset time)
    {
        WriteUInt32((uint)time.ToUnixTimeSeconds());
    }

    public Span<byte> GetSpan(int size)
    {
        if (_buffer == null)
            throw new NullReferenceException(nameof(_buffer));

        // The buffer is too small to fit the requested span. Double its size and copy the memory
        if (_buffer.Length < _writtenBytes + size)
        {
            byte[] newBuffer = s_bufferPool.Rent(_buffer.Length * 2);
            _buffer.AsSpan(0, _writtenBytes).CopyTo(newBuffer);
            s_bufferPool.Return(_buffer);
            _buffer = newBuffer;
        }

        Span<byte> span = _buffer.AsSpan(_writtenBytes, size);
        _writtenBytes += size;
        return span;
    }
}
