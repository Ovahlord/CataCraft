// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerUpdateAccountDataComplete : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_UPDATE_ACCOUNT_DATA_COMPLETE;

    public AccountDataType DataType { get; set; }
    public uint Result { get; set; }

    public ServerUpdateAccountDataComplete()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt32((uint)DataType);
        writer.WriteUInt32(Result);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
