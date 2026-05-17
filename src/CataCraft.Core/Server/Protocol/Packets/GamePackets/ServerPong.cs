// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerPong : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_PONG;

    public uint Serial { get; set; }

    public ServerPong()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt32(Serial);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
