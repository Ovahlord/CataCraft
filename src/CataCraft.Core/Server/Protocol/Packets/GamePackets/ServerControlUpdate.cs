// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.Entities.Object;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerControlUpdate : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_CONTROL_UPDATE;

    public bool On { get; set; }
    public WowGuid Guid { get; set; } = null!;

    public ServerControlUpdate()
    {
    }


    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WritePackGUID(Guid);
        writer.WriteBool(On);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
