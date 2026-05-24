// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerLogoutResponse : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_LOGOUT_RESPONSE;

    public int LogoutResult { get; set; }
    public bool InstantLogout { get; set; }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteInt32(LogoutResult);
        writer.WriteBool(InstantLogout);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
