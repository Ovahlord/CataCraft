// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public struct ClientCharDelete
{
    public WowGuid Guid { get; set; } = new();

    private ClientCharDelete(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Guid = reader.ReadUInt64();
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientCharDelete charDelete = new(payload);

        RealmCharacterRequestManager.RequestCharacterDeletion(session, charDelete.Guid);
        return ValueTask.CompletedTask;
    }

}
