// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Numerics;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.Entities.Object;
using CataCraft.Core.Game.Entities.Player;
using CataCraft.Core.Game.Time;
using CataCraft.Core.Server.Networking;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public struct ClientPlayerLogin
{
    public WowGuid PlayerGUID { get; private set; } = new();

    private ClientPlayerLogin(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);

        WowGuid playerGUID = new();
        playerGUID[2] = reader.ReadBit();
        playerGUID[3] = reader.ReadBit();
        playerGUID[0] = reader.ReadBit();
        playerGUID[6] = reader.ReadBit();
        playerGUID[4] = reader.ReadBit();
        playerGUID[5] = reader.ReadBit();
        playerGUID[1] = reader.ReadBit();
        playerGUID[7] = reader.ReadBit();

        reader.ReadByteSeq(ref playerGUID, 2);
        reader.ReadByteSeq(ref playerGUID, 7);
        reader.ReadByteSeq(ref playerGUID, 0);
        reader.ReadByteSeq(ref playerGUID, 3);
        reader.ReadByteSeq(ref playerGUID, 5);
        reader.ReadByteSeq(ref playerGUID, 6);
        reader.ReadByteSeq(ref playerGUID, 1);
        reader.ReadByteSeq(ref playerGUID, 4);

        PlayerGUID = playerGUID;
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientPlayerLogin playerLogin = new (payload);
        Console.WriteLine($"Player {playerLogin.PlayerGUID} logging in.");

        await using RealmDbContext realmDb = new();
        Character? characterEntry = await realmDb.Characters
            .Include(c => c.Stats)
            .Include(c => c.RealmCharacter)
            .Where(c => c.Id == playerLogin.PlayerGUID.Counter
                        && c.RealmCharacter != null
                        && c.RealmCharacter.RealmId == session.Realm.RealmId
                        && c.RealmCharacter.GameAccountId == session.GameAccountId)
            .FirstOrDefaultAsync();

        if (characterEntry == null || characterEntry.Stats == null)
        {
            session.Close();
            return;
        }

        Player? player = Player.CreatePlayerFromData(characterEntry, session);
        if (player == null)
        {
            session.Close();
            return;
        }

        player.MovementStatus.Position = new Vector3(-4025.6675f, -3915.7979f, 201.67465f);

        ServerLoginVerifiyWorld verifiyWorld = new()
        {
            MapID = 0,
            Position = player.MovementStatus.Position
        };

        session.EnqueuePacket(ref verifiyWorld);

        await player.SendCharacterAccountDataAsync();

        ServerTutorialFlags tutorialFlags = new()
        {
            TutorialData = session.TutorialBits
        };
        session.EnqueuePacket(ref tutorialFlags);

        ServerLoginSetTimeSpeed loginSetTimeSpeed = new()
        {
            GameTime = new WowTime(DateTimeOffset.Now).PackedTime
        };
        session.EnqueuePacket(ref loginSetTimeSpeed);

        ServerFeatureSystemStatus featureSystemStatus = new();
        session.EnqueuePacket(ref featureSystemStatus);

        ServerInitializeFactions initializeFactions = new()
        {
            FactionStandings = new FactionStanding[256],
            FactionFlags = new  FactionFlags[256]
        };

        Array.Fill(initializeFactions.FactionFlags, FactionFlags.Visible);

        session.EnqueuePacket(ref initializeFactions);

        ServerUpdateObject updateObject = new();
        updateObject.AddObjectToCreate(
            player,
            true,
            DataFieldVisibilityFlags.Public | DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.UnitAll | DataFieldVisibilityFlags.Dynamic,
            new CreateObjectBits()
            {
                MovementUpdate = true,
                ThisIsYou = true
            });

        session.EnqueuePacket(ref updateObject);

        //ServerLoadCUFProfiles loadCUFProfiles = new();
        //session.EnqueuePacket(loadCUFProfiles);
//
        //ServerTimeSyncRequest timeSyncRequest = new();
        //session.EnqueuePacket(timeSyncRequest);
    }
}
