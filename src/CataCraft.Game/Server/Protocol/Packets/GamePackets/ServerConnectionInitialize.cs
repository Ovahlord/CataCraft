// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Server.Protocol.Packets;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public struct ServerConnectionInitialize : IServerPacket
{
    public int Opcode => 0;

    private const string ConnectionInitializer = "WORLD OF WARCRAFT CONNECTION - SERVER TO CLIENT";

    public ServerConnectionInitialize()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteCString(ConnectionInitializer);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
