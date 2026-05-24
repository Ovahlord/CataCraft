// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerInitializeFactions : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_INITIALIZE_FACTIONS;

    public FactionStanding[] FactionStandings { get; set; } = [];
    public FactionFlags[] FactionFlags { get; set; } = [];

    public ServerInitializeFactions()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteInt32(FactionStandings.Length);

        for (int i = 0; i < FactionStandings.Length; ++i)
        {
            writer.WriteUInt8((byte)FactionFlags[i]);
            writer.WriteInt32((int)FactionStandings[i]);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
