// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public struct ServerLogoutComplete : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_LOGOUT_COMPLETE;

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        buffer = [];
        payloadLength = 0;
    }
}
