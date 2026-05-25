// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public struct ServerCreateChar : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_CREATE_CHAR;

    public ResponseCodes Code { get; set; }

    public ServerCreateChar()
    {
    }

    public ServerCreateChar(ResponseCodes code)
    {
        Code = code;
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt8((byte)Code);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
