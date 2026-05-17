// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientConnectionInitialize
{
    private const string ConnectionInitializer = "WORLD OF WARCRAFT CONNECTION - CLIENT TO SERVER";
    private string ReceivedConnectionInitializer { get; set; } = string.Empty;

    private ClientConnectionInitialize(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        ReceivedConnectionInitializer = reader.ReadCString();
    }

    public static bool HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientConnectionInitialize packet = new(payload);
        return packet.ReceivedConnectionInitializer.Equals(ConnectionInitializer);
    }
}
