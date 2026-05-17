// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets;

public abstract class GamePacket : ServerPacket
{
    protected override int HeaderSize => 5;

    protected GamePacket(int opcode) : base(opcode)
    {
    }

    protected override void WriteHeader(IBufferWriter<byte> writer, PacketCrypt? packetCrypt)
    {
        int packetSize = WrittenBytes + sizeof(GameServerOpcodes);
        int headerIndex = 0;

        Span<byte> headerSpan = stackalloc byte[HeaderSize];

        if (packetSize > 0x7FFF)
            headerSpan[headerIndex++] = (byte)(0x80 | (0xFF & (packetSize >> 16)));

        headerSpan[headerIndex++] = (byte)(0xFF & (packetSize >> 8));
        headerSpan[headerIndex++] = (byte)(0xFF & packetSize);

        headerSpan[headerIndex++] = (byte)(0xFF & Opcode);
        headerSpan[headerIndex++] = (byte)(0xFF & (Opcode >> 8));

        if (packetCrypt != null)
            packetCrypt.EncryptSend(headerSpan.Slice(0, headerIndex));

        writer.Write(headerSpan.Slice(0, headerIndex));
    }
}
