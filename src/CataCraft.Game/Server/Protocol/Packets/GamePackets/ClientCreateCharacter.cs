// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using CataCraft.DBC;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

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

    private struct CharacterCreationPositionData
    {
        public CharacterCreationPositionData(int mapId, float positionX, float positionY, float positionZ, float facing)
        {
            MapId = mapId;
            PositionX = positionX;
            PositionY = positionY;
            PositionZ = positionZ;
            Facing = facing;
        }

        public int MapId { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Facing { get; set; }
    }

    private static readonly Dictionary<ChrRace, CharacterCreationPositionData> s_creationPositionData = new()
    {
        { ChrRace.Human, new CharacterCreationPositionData(0, -8914.57f, -133.909f, 80.5378f, 5.13806f) },
        { ChrRace.Orc, new CharacterCreationPositionData(1, -618.518f, -4251.67f, 38.718f, 4.72222f) },
        { ChrRace.Dwarf, new CharacterCreationPositionData(0, -6240.32f, 331.033f, 382.758f, 6.17716f) },
        { ChrRace.Nightelf, new CharacterCreationPositionData(1, 10311.3f, 832.463f, 1326.41f, 5.69632f) },
        { ChrRace.Undead, new CharacterCreationPositionData(0, 1699.85f, 1706.56f, 135.928f, 4.88839f) },
        { ChrRace.Tauren, new CharacterCreationPositionData(1, -2915.55f, -257.347f, 59.2693f, 0.302378f) },
        { ChrRace.Gnome, new CharacterCreationPositionData(0, -4983.42f, 877.7f, 274.31f, 3.06393f) },
        { ChrRace.Troll, new CharacterCreationPositionData(1, -1171.45f, -5263.65f, 0.847728f, 5.78945f) },
        { ChrRace.Goblin, new CharacterCreationPositionData(648, -8423.81f, 1361.3f, 104.671f, 1.55428f) },
        { ChrRace.Bloodelf, new CharacterCreationPositionData(530, 10349.6f, -6357.29f, 33.4026f, 5.31605f) },
        { ChrRace.Draenei, new CharacterCreationPositionData(530, -3961.64f, -13931.2f, 100.615f, 2.08364f) },
        { ChrRace.Worgen, new CharacterCreationPositionData(654, -1451.53f, 1403.35f, 35.5561f, 0.333847f) }
    };

    private static readonly CharacterCreationPositionData s_deathKnightCreationPositionData = new(609, 2355.84f, -5664.77f, 426.028f, 3.93485f);

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
            !DBCManager.SChrClassesStore.ContainsKey(createCharacter.ClassID))
        {
            SendCharCreateResponse(ResponseCodes.CharCreateError, session);
            return;
        }

        CharacterCreationPositionData positionData;
        if ((ChrClass)createCharacter.ClassID == ChrClass.DeathKnight)
            positionData = s_deathKnightCreationPositionData;
        else if (!s_creationPositionData.TryGetValue((ChrRace)createCharacter.RaceID, out positionData))
        {
            SendCharCreateResponse(ResponseCodes.CharCreateError, session);
            return;
        }

        await using RealmDbContext realmDb = new();
        List<Character> realmCharacters = await realmDb.Characters
            .Where(rc => rc.RealmId == session.Realm.RealmId && rc.GameAccountId == session.GameAccountId)
            .ToListAsync();

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

        byte listPosition = 1;
        if (realmCharacters.Count > 0)
        {
            listPosition = realmCharacters.Max(rc => rc.ListPositionIndex);
            listPosition += 1;
        }

        CharacterStats characterStats = new()
        {
            MapId = positionData.MapId,
            PositionX = positionData.PositionX,
            PositionY = positionData.PositionY,
            PositionZ = positionData.PositionZ,
            Facing = positionData.Facing
        };

        Character character = new()
        {
            RealmId =  session.Realm.RealmId,
            GameAccountId = session.GameAccountId,
            ListPositionIndex = listPosition,
            Name = createCharacter.Name,
            RaceId = createCharacter.RaceID,
            ClassId = createCharacter.ClassID,
            SexId = createCharacter.SexID,
            HairStyleId = createCharacter.HairStyleID,
            HairColorId = createCharacter.HairColorID,
            FacialHairStyleId = createCharacter.FacialHairStyleID,
            FaceId = createCharacter.FaceID,
            Stats = characterStats,
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
