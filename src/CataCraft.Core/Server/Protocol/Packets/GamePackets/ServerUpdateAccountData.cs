// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Utils;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerUpdateAccountData : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_UPDATE_ACCOUNT_DATA;

    public AccountDataType DataType { get; set; }
    public DateTimeOffset Time { get; set; }
    public byte[]? Data { get; set; }

    public ServerUpdateAccountData()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt32((uint)DataType);
        writer.WriteTime(Time);

        if (Data == null)
        {
            writer.WriteInt32(0);
        }
        else
        {
            writer.WriteInt32(Data.Length);
            if (Data.Length > 0)
                writer.WriteBytes(ZLib.DeflateData(Data));
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
