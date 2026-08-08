// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Game.Server.Networking;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientLogoutRequest
{
    private const int DefaultLogoutDelay = 20000; // Hardcoded in client

    public ClientLogoutRequest(ReadOnlySequence<byte> _)
    {
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> _, GameSession session)
    {
        ServerLogoutResponse serverLogoutResponse = new();
        session.EnqueuePacket(ref serverLogoutResponse);

        if (session.Player == null || session.Player.MapInstance == null)
            return;

        await Task.Delay(DefaultLogoutDelay);

        session.Player.MapInstance.RemoveWowObject(session.Player);
        session.Player.MapInstance = null;
        session.Player = null;

        ServerLogoutComplete serverLogoutComplete = new();
        session.EnqueuePacket(ref serverLogoutComplete);
    }
}
