// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientLogoutRequest
{
    public ClientLogoutRequest(ReadOnlySequence<byte> _)
    {
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> _, GameSession session)
    {
        ServerLogoutResponse serverLogoutResponse = new()
        {
            InstantLogout =  true,
        };

        session.EnqueuePacket(ref serverLogoutResponse);

        //await Task.Delay(20000);

        ServerLogoutComplete serverLogoutComplete = new();
        session.EnqueuePacket(ref serverLogoutComplete);

        // Free the player reference so that GC may collect it
        session.Player = null;
    }
}
