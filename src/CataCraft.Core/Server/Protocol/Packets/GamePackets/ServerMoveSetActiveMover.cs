// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.Entities.Object;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerMoveSetActiveMover : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_MOVE_SET_ACTIVE_MOVER;

    public WowGuid MoverGUID { get; set; } = null!;

    public ServerMoveSetActiveMover()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteBit(MoverGUID[5]);
        writer.WriteBit(MoverGUID[7]);
        writer.WriteBit(MoverGUID[3]);
        writer.WriteBit(MoverGUID[6]);
        writer.WriteBit(MoverGUID[0]);
        writer.WriteBit(MoverGUID[4]);
        writer.WriteBit(MoverGUID[1]);
        writer.WriteBit(MoverGUID[2]);

        writer.WriteByteSeq(MoverGUID[6]);
        writer.WriteByteSeq(MoverGUID[2]);
        writer.WriteByteSeq(MoverGUID[3]);
        writer.WriteByteSeq(MoverGUID[0]);
        writer.WriteByteSeq(MoverGUID[5]);
        writer.WriteByteSeq(MoverGUID[7]);
        writer.WriteByteSeq(MoverGUID[1]);
        writer.WriteByteSeq(MoverGUID[4]);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
