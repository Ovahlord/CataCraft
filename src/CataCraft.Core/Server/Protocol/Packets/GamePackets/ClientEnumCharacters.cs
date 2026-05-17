// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientEnumCharacters
{
    private ClientEnumCharacters(in ReadOnlySequence<byte> _)
    {
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        RealmCharacterRequestManager.RequestEnumCharacters(session);
        return ValueTask.CompletedTask;
    }
}
