// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerClientCacheVersion : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_CLIENT_CACHE_VERSION;

    public int Version { get; set; }

    public ServerClientCacheVersion()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteInt32(Version);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
