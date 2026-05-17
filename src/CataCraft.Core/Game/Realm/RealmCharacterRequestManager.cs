// This file is part of the CataCraft project, which is published under the MIT license.

using System.Threading.Channels;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GamePackets;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Game.Realm;

public static class RealmCharacterRequestManager
{
    private struct CreateCharacterRequest
    {
        public GameSession Session { get; set; }
        public string Name { get; set; }
        public byte RaceId { get; set; }
        public byte ClassId { get; set; }
        public byte SexId { get; set; }
        public byte SkinId { get; set; }
        public byte FaceId { get; set; }
        public byte HairStyleId { get; set; }
        public byte HairColorId { get; set; }
        public byte FacialHairStyleId { get; set; }
        public byte OutfitId { get; set; }
    }

    struct CharacterDeletionRequest
    {
        public GameSession Session { get; set; }
        public WowGuid CharacterGuid { get; set; }
    }

    private static readonly Channel<GameSession> s_enumCharactersRequests = Channel.CreateUnbounded<GameSession>();
    private static readonly Channel<CreateCharacterRequest> s_createCharacterRequests = Channel.CreateUnbounded<CreateCharacterRequest>();
    private static readonly Channel<CharacterDeletionRequest> s_deleteCharacterRequests = Channel.CreateUnbounded<CharacterDeletionRequest>();

    private const int MaxCharactersPerRealm = 10;
    private const int MaxCharactersPerAccount = 50;

    static RealmCharacterRequestManager()
    {
        _ = ProcessEnumCharactersRequestsAsync();
        _ = ProcessCreateCharacterRequestsAsync();
        _ = ProcessDeleteCharacterRequestAsync();
    }

    private static async Task ProcessEnumCharactersRequestsAsync()
    {
        while (true)
        {
            try
            {
                await s_enumCharactersRequests.Reader.WaitToReadAsync();

                while (s_enumCharactersRequests.Reader.TryRead(out GameSession? session))
                {
                    if (!session.IsOpen)
                        continue;

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    private static async Task ProcessCreateCharacterRequestsAsync()
    {
        while (true)
        {
            try
            {
                await s_createCharacterRequests.Reader.WaitToReadAsync();

                while (s_createCharacterRequests.Reader.TryRead(out CreateCharacterRequest request))
                {
                    GameSession session = request.Session;
                    if (!session.IsOpen)
                        continue;

                    await using RealmDbContext realmDb = new();
                    List<RealmCharacter> realmCharacters = await realmDb.RealmCharacters
                        .Include(rc => rc.Character)
                        .Where(rc => rc.RealmId == session.Realm.RealmId && rc.GameAccountId == session.GameAccountId)
                        .ToListAsync();

                    ServerCreateChar createChar = new();

                    if (realmCharacters.Count == 0 && request.Session.Realm.LockedForNewPlayers)
                    {
                        createChar.Code = ResponseCodes.CharCreateOnlyExisting;
                        session.EnqueuePacket(ref createChar);
                        continue;
                    }

                    if (realmCharacters.Count >= MaxCharactersPerRealm)
                    {
                        createChar.Code = ResponseCodes.CharCreateServerLimit;
                        session.EnqueuePacket(ref createChar);
                        continue;
                    }

                    // Normalize the account name
                     request.Name = char.ToUpperInvariant(request.Name[0]) + request.Name.Substring(1);

                    if (await realmDb.Characters.AnyAsync(c => c.Name.Equals(request.Name)))
                    {
                        createChar.Code = ResponseCodes.CharCreateNameInUse;
                        session.EnqueuePacket(ref createChar);
                        continue;
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
                        Name = request.Name,
                        RaceId = request.RaceId,
                        ClassId = request.ClassId,
                        SexId = request.SexId,
                        HairStyleId = request.HairStyleId,
                        HairColorId = request.HairColorId,
                        FacialHairStyleId = request.FacialHairStyleId,
                        FaceId = request.FaceId,
                        Stats = characterStats,
                        RealmCharacter = realmCharacter
                    };

                    realmDb.Characters.Add(character);

                    int affectedRows = await realmDb.SaveChangesAsync();
                    if (affectedRows == 0)
                    {
                        createChar.Code = ResponseCodes.CharCreateFailed;
                        session.EnqueuePacket(ref createChar);
                    }
                    else
                    {
                        createChar.Code = ResponseCodes.CharCreateSuccess;
                        session.EnqueuePacket(ref createChar);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    private static async Task ProcessDeleteCharacterRequestAsync()
    {
        while (true)
        {
            try
            {
                await s_deleteCharacterRequests.Reader.WaitToReadAsync();

                while (s_deleteCharacterRequests.Reader.TryRead(out CharacterDeletionRequest request))
                {
                    GameSession session = request.Session;
                    if (!session.IsOpen)
                        continue;

                    await using RealmDbContext realmDb = new();
                    uint characterId = request.CharacterGuid.Counter;

                    Character? character = await realmDb.Characters
                        .Include(c => c.RealmCharacter)
                        .FirstOrDefaultAsync(c => c.Id == characterId);

                    ServerDeleteChar deleteChar = new()
                    {
                        Code = ResponseCodes.CharDeleteFailed
                    };

                    if (character == null
                        || character.RealmCharacter == null
                        || character.RealmCharacter.RealmId != session.Realm.RealmId
                        || character.RealmCharacter.GameAccountId != session.GameAccountId)
                    {
                        session.EnqueuePacket(ref deleteChar);
                        continue;
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

                    // Save all changes to the database
                    await realmDb.SaveChangesAsync();

                    deleteChar.Code = ResponseCodes.CharDeleteSuccess;
                    session.EnqueuePacket(ref deleteChar);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public static void RequestEnumCharacters(GameSession session)
    {
        s_enumCharactersRequests.Writer.TryWrite(session);
    }

    public static void RequestCharacterCreation(GameSession session, string name, byte raceId, byte classId, byte sexId, byte skinId, byte faceId, byte hairStyleId, byte hairColorId, byte facialHairStyleId, byte outfitId)
    {
        s_createCharacterRequests.Writer.TryWrite(new CreateCharacterRequest()
        {
            Session = session,
            Name = name,
            RaceId = raceId,
            ClassId =  classId,
            SexId = sexId,
            SkinId = skinId,
            FaceId = faceId,
            HairStyleId = hairStyleId,
            HairColorId = hairColorId,
            FacialHairStyleId = facialHairStyleId,
            OutfitId = outfitId
        });
    }

    public static void RequestCharacterDeletion(GameSession session, WowGuid characterGuid)
    {
        s_deleteCharacterRequests.Writer.TryWrite(new CharacterDeletionRequest()
        {
            Session = session,
            CharacterGuid = characterGuid
        });
    }
}
