// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerTimeSyncRequest : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_TIME_SYNC_REQUEST;

    public uint SequenceIndex { get; set; }

    public ServerTimeSyncRequest()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt32(SequenceIndex);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
