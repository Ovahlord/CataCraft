// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Entities.Player;
using CataCraft.Game.Server.Networking;
using CataCraft.Game.World.Map;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientPlayerLogin
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
        WowGuid playerGuid = playerLogin.PlayerGUID;

        Console.WriteLine($"Player {playerLogin.PlayerGUID} logging in.");

        await using RealmDbContext realmDb = new();
        Character? characterDbData = await realmDb.Characters
            .Include(c => c.Stats)
            .Include(c => c.CharacterData)
            .Where(c => c.Id == playerGuid.Counter
                        && c.RealmId == session.Realm.RealmId
                        && c.GameAccountId == session.GameAccountId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (characterDbData == null || characterDbData.Stats == null)
        {
            session.Close();
            return;
        }


        MapInstance? instance = await session.Realm.World.GetInstanceForMapIdAsync(characterDbData.Stats.MapId);
        if (instance == null)
        {
            session.Close();
            return;
        }

        // Attempt to pick up the already existing player toon in case of a disconnect
        if (!instance.TryGetPlayer(playerGuid, out Player? player))
        {
            // No player found - try to create a new entity
            if (!Player.TryCreatePlayerFromData(characterDbData, out player))
            {
                session.Close();
                return;
            }

            Console.WriteLine("Created new player object for login");
        }
        else
        {
            Console.WriteLine("Picked up existing player object for login");
        }

        if (!instance.AddWowObject(player))
        {
            session.Close();
            return;
        }

        player.Session = session;
        session.Player = player;
        session.Player.MapInstance = instance;

        // Player has been successfully added to the map instance. Verify world login
        SendLoginVerifyWorld(session, player);

        // Send the per-character data times
        SendCharacterDataTimes(session,  characterDbData);

        // Send the tutorial flags
        SendTutorialFlags(session);

        // Set the game time speed
        SendSetTimeSpeed(session);

        // Send the feature status
        SendFeatureSystemStatus(session);
    }

    private static void SendLoginVerifyWorld(GameSession session, Player player)
    {
        if (player.MapInstance == null)
            return;

        ServerLoginVerifiyWorld loginVerifyWorld = new(player.MovementStatus.Position, player.MovementStatus.Facing, player.MapInstance.MapRecId);
        session.EnqueuePacket(ref loginVerifyWorld);
    }

    private static void SendCharacterDataTimes(GameSession session, Character characterData)
    {
        ServerAccountDataTimes accountDataTimes = new(characterData.CharacterData);
        session.EnqueuePacket(ref accountDataTimes);
    }

    private static void SendTutorialFlags(GameSession session)
    {
        ServerTutorialFlags serverTutorialFlags = new(session.TutorialBits);
        session.EnqueuePacket(ref serverTutorialFlags);
    }

    private static void SendSetTimeSpeed(GameSession session)
    {
        ServerLoginSetTimeSpeed loginSetTimeSpeed = new();
        session.EnqueuePacket(ref loginSetTimeSpeed);
    }

    private static void SendFeatureSystemStatus(GameSession session)
    {
        ServerFeatureSystemStatus featureSystemStatus = new();
        session.EnqueuePacket(ref featureSystemStatus);
    }
}
