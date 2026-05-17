// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Game.Server.Networking;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientLogoutRequest
{
    public ClientLogoutRequest(ReadOnlySequence<byte> _)
    {
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> _, GameSession session)
    {
        ServerLogoutResponse serverLogoutResponse = new();
        session.EnqueuePacket(ref serverLogoutResponse);

        if (session.Player == null || session.MapInstance == null)
            return;

        await Task.Delay(20000);

        session.MapInstance?.RemoveWowObject(session.Player);
        session.Player = null;

        ServerLogoutComplete serverLogoutComplete = new();
        session.EnqueuePacket(ref serverLogoutComplete);
    }
}
