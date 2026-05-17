// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerAccountDataTimes : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_ACCOUNT_DATA_TIMES;

    public DateTimeOffset ServerTime { get; set; }
    public int Mask { get; set; }
    public DateTimeOffset[] AccountTimes { get; set; } = [];

    public ServerAccountDataTimes()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteTime(ServerTime);
        writer.WriteUInt8(1);
        writer.WriteInt32(Mask);

        foreach (DateTimeOffset accountTime in AccountTimes)
            writer.WriteTime(accountTime);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
