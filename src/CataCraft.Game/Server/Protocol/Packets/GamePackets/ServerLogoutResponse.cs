// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Server.Protocol.Packets;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ServerLogoutResponse : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_LOGOUT_RESPONSE;

    public LogoutResponseResult LogoutResult { get; set; }
    public bool InstantLogout { get; set; }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteInt32((int)LogoutResult);
        writer.WriteBool(InstantLogout);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
