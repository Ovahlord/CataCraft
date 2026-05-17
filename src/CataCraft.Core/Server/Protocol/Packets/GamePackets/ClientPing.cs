// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientPing
{
    public uint Latency { get; private set; }
    public uint Serial { get; private set; }

    public ClientPing(ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Latency = reader.ReadUInt32();
        Serial = reader.ReadUInt32();
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientPing ping = new(payload);
        ServerPong pong = new()
        {
            Serial = ping.Serial
        };

        session.EnqueuePacket(ref pong);

        return ValueTask.CompletedTask;
    }
}
