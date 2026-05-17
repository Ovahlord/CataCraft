// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using CataCraft.Game.Server.Protocol.Packets.GamePackets.SubStructures;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientEnumCharacters
{
    private ClientEnumCharacters(in ReadOnlySequence<byte> _)
    {
        // No payload is being parsed
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        await using RealmDbContext realmDb = new();
        GameSession gameSession = session;
        List<Character> realmCharacters = await realmDb.Characters
            .Include(rc => rc.Stats)
            .Where(rc => rc.RealmId == gameSession.Realm.RealmId && rc.GameAccountId == gameSession.GameAccountId)
            .OrderBy(rc => rc.ListPositionIndex)
            .AsNoTracking()
            .ToListAsync();

        ServerEnumCharactersResult enumCharactersResult = new()
        {
            Success = true,
        };

        foreach (Character character in realmCharacters)
        {
            CharacterStats? stats = character.Stats;
            if (stats == null)
                continue;

            enumCharactersResult.Characters.Add(new CharacterListEntry()
            {
                Guid = new WowGuid(WowGuidType.Player, (uint)character.Id),
                Name = character.Name,
                ClassID = character.ClassId,
                FaceID = character.FaceId,
                HairStyle = character.HairStyleId,
                HairColor = character.HairColorId,
                RaceID = character.RaceId,
                SexID = character.SexId,
                SkinID = character.SkinId,
                FacialHair = character.FacialHairStyleId,
                ExperienceLevel = stats.ExperienceLevel,
                Flags = (CharacterFlags)(stats.CharacterFlags),
                Flags2 = (CharacterFlags2)(stats.CharacterFlags2),
                ListPosition = character.ListPositionIndex,
                ZoneID = stats.AreaId,
                MapID = stats.MapId,
                PreloadPos = [stats.PositionX, stats.PositionY, stats.PositionZ],
                FirstLogin = stats.FirstLogin
            });
        }

        session.EnqueuePacket(ref enumCharactersResult);
    }
}
