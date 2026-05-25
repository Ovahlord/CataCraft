// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Server.Networking;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

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
            .Include(c => c.RealmCharacter)
            .FirstOrDefaultAsync(c => c.Id == characterId);

        if (character == null ||
            character.RealmCharacter == null ||
            character.RealmCharacter.RealmId != session.Realm.RealmId ||
            character.RealmCharacter.GameAccountId != session.GameAccountId)
        {
            SendCharDeleteResponse(ResponseCodes.CharDeleteFailed, session);
            return;
        }

        // Delete character
        realmDb.Characters.Remove(character);

        // Update the list index of the remaining characters
        if (character.RealmCharacter != null)
        {
            byte listPosition = character.RealmCharacter.ListPositionIndex;
            List<RealmCharacter> trailingCharacters = await realmDb.RealmCharacters
                .Where(rc => rc.ListPositionIndex > listPosition
                             && rc.RealmId == session.Realm.RealmId
                             && rc.GameAccountId == session.GameAccountId)
                .ToListAsync();

            foreach (RealmCharacter realmCharacter in trailingCharacters)
            {
                realmCharacter.ListPositionIndex -= 1;
            }
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
