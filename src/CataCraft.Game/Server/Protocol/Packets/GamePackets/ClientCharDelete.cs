// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public struct ClientCharDelete
{
    public WowGuid Guid { get; set; } = new();

    private ClientCharDelete(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Guid = reader.ReadUInt64();
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientCharDelete charDelete = new(payload);

        await using RealmDbContext realmDb = new();
        uint characterId = charDelete.Guid.Counter;

        Character? character = await realmDb.Characters
            .FirstOrDefaultAsync(c => c.Id == characterId);

        if (character == null ||
            character.RealmId != session.Realm.RealmId ||
            character.GameAccountId != session.GameAccountId)
        {
            SendCharDeleteResponse(ResponseCodes.CharDeleteFailed, session);
            return;
        }

        // Delete character
        realmDb.Characters.Remove(character);

        // Update the list index of the remaining characters
        byte listPosition = character.ListPositionIndex;
        List<Character> trailingCharacters = await realmDb.Characters
            .Where(c => c.ListPositionIndex > listPosition
                         && c.RealmId == session.Realm.RealmId
                         && c.GameAccountId == session.GameAccountId)
            .ToListAsync();

        foreach (Character realmCharacter in trailingCharacters)
        {
            realmCharacter.ListPositionIndex -= 1;
        }

        try
        {
            // Save all changes to the database
            await realmDb.SaveChangesAsync();
            SendCharDeleteResponse(ResponseCodes.CharDeleteSuccess, session);
        }
        catch (Exception)
        {
            SendCharDeleteResponse(ResponseCodes.CharDeleteFailed, session);
        }
    }

    private static void SendCharDeleteResponse(ResponseCodes response, GameSession session)
    {
        ServerDeleteChar deleteChar = new(response);
        session.EnqueuePacket(ref deleteChar);
    }
}
