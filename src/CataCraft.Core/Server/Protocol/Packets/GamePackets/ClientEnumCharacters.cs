// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientEnumCharacters
{
    private ClientEnumCharacters(in ReadOnlySequence<byte> _)
    {
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        await using RealmDbContext realmDb = new();
        GameSession gameSession = session;
        List<RealmCharacter> realmCharacters = await realmDb.RealmCharacters
            .Include(rc => rc.Character)
            .Include(rc => rc.Character.Stats)
            .Where(rc => rc.RealmId == gameSession.Realm.RealmId && rc.GameAccountId == gameSession.GameAccountId)
            .OrderBy(rc => rc.ListPositionIndex)
            .AsNoTracking()
            .ToListAsync();

        ServerEnumCharactersResult enumCharactersResult = new()
        {
            Success = true,
        };

        foreach (RealmCharacter realmCharacter in realmCharacters)
        {
            Character character = realmCharacter.Character;
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
                ListPosition = realmCharacter.ListPositionIndex,
                ZoneID = stats.AreaId,
                FirstLogin = stats.FirstLogin
            });
        }

        session.EnqueuePacket(ref enumCharactersResult);
    }
}
