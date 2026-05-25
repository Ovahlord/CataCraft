// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientTutorialReset
{
    public ClientTutorialReset(ReadOnlySequence<byte> payload)
    {
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        Array.Fill(session.TutorialBits, 0u);
        return ValueTask.CompletedTask;
    }
}
