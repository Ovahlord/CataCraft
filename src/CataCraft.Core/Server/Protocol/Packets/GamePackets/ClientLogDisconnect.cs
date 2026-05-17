// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientLogDisconnect
{
    public LogDisconnectReason Reason { get; private set; }

    private ClientLogDisconnect(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Reason = (LogDisconnectReason)reader.ReadUInt32();
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientLogDisconnect logDisconnect = new (payload);
        Console.WriteLine($"Session for account {session.AccountName} disconnected for reason: {logDisconnect.Reason}");

        return ValueTask.CompletedTask;
    }
}
