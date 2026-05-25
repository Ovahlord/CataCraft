// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Server.Networking;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using CataCraft.DBC;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public struct ClientCreateCharacter
{
    public string Name { get; private set; } = string.Empty;
    public byte RaceID { get; private set; }
    public byte ClassID { get; private set; }
    public byte SexID { get; private set; }
    public byte SkinID { get; private set; }
    public byte FaceID { get; private set; }
    public byte HairStyleID { get; private set; }
    public byte HairColorID { get; private set; }
    public byte FacialHairStyleID { get; private set; }
    public byte OutfitID { get; private set; }

    private const int MaxCharactersPerRealm   = 10;
    private const int MaxCharactersPerAccount = 50;

    private ClientCreateCharacter(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Name = reader.ReadCString();
        RaceID = reader.ReadUInt8();
        ClassID = reader.ReadUInt8();
        SexID = reader.ReadUInt8();
        SkinID = reader.ReadUInt8();
        FaceID = reader.ReadUInt8();
        HairStyleID = reader.ReadUInt8();
        HairColorID = reader.ReadUInt8();
        FacialHairStyleID = reader.ReadUInt8();
        OutfitID = reader.ReadUInt8();
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientCreateCharacter createCharacter = new(payload);

        if (!DBCManager.SChrRacesStore.ContainsKey(createCharacter.RaceID) ||
            DBCManager.SChrClassesStore.ContainsKey(createCharacter.ClassID))
        {
            SendCharCreateResponse(ResponseCodes.CharCreateError, session);
            return;
        }

        await using RealmDbContext realmDb = new();
        List<RealmCharacter> realmCharacters = await realmDb.RealmCharacters
            .Include(rc => rc.Character)
            .Where(rc => rc.RealmId == session.Realm.RealmId && rc.GameAccountId == session.GameAccountId)
            .ToListAsync();

        ServerCreateChar createChar = new();

        if (realmCharacters.Count == 0 && session.Realm.LockedForNewPlayers)
        {
            SendCharCreateResponse(ResponseCodes.CharCreateOnlyExisting, session);
            return;
        }

        if (realmCharacters.Count >= MaxCharactersPerRealm)
        {
            SendCharCreateResponse(ResponseCodes.CharCreateServerLimit, session);
            return;
        }

        // Normalize the account name
        createCharacter.Name = char.ToUpperInvariant(createCharacter.Name[0]) + createCharacter.Name.Substring(1);

        if (await realmDb.Characters.AnyAsync(c => c.Name.Equals(createCharacter.Name)))
        {
            SendCharCreateResponse(ResponseCodes.CharCreateNameInUse, session);
            return;
        }

        CharacterStats characterStats = new();

        byte listPosition = 1;
        if (realmCharacters.Count > 0)
        {
            listPosition = realmCharacters.Max(rc => rc.ListPositionIndex);
            listPosition += 1;
        }

        RealmCharacter realmCharacter = new()
        {
            RealmId =  session.Realm.RealmId,
            GameAccountId = session.GameAccountId,
            ListPositionIndex = listPosition
        };

        Character character = new()
        {
            Name = createCharacter.Name,
            RaceId = createCharacter.RaceID,
            ClassId = createCharacter.ClassID,
            SexId = createCharacter.SexID,
            HairStyleId = createCharacter.HairStyleID,
            HairColorId = createCharacter.HairColorID,
            FacialHairStyleId = createCharacter.FacialHairStyleID,
            FaceId = createCharacter.FaceID,
            Stats = characterStats,
            RealmCharacter = realmCharacter
        };

        realmDb.Characters.Add(character);

        try
        {
            int affectedRows = await realmDb.SaveChangesAsync();
            if (affectedRows == 0)
                SendCharCreateResponse(ResponseCodes.CharCreateFailed, session);
            else
                SendCharCreateResponse(ResponseCodes.CharCreateSuccess, session);
        }
        catch (Exception)
        {
            SendCharCreateResponse(ResponseCodes.CharCreateFailed, session);
        }
    }

    private static void SendCharCreateResponse(ResponseCodes response, GameSession session)
    {
        ServerCreateChar createChar = new(response);
        session.EnqueuePacket(ref createChar);
    }
}
