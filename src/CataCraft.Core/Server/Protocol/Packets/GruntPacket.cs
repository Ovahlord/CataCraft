// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;

namespace CataCraft.Core.Server.Protocol.Packets;

public abstract class GruntPacket : ServerPacket
{
    protected override int HeaderSize => 1;

    protected GruntPacket(int opcode) : base(opcode)
    {
    }

    protected override void WriteHeader(IBufferWriter<byte> writer, PacketCrypt? _)
    {
        Span<byte> headerSpan = stackalloc byte[HeaderSize];
        headerSpan[0] = (byte)Opcode;
        writer.Write(headerSpan);
    }
}
