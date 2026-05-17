// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Numerics;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Game.World.Entities.Player;
using CataCraft.Core.Game.World.Time;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientPlayerLogin
{
    public WowGuid PlayerGUID { get; private set; } = new();

    private ClientPlayerLogin(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);

        PlayerGUID[2] = reader.ReadBit();
        PlayerGUID[3] = reader.ReadBit();
        PlayerGUID[0] = reader.ReadBit();
        PlayerGUID[6] = reader.ReadBit();
        PlayerGUID[4] = reader.ReadBit();
        PlayerGUID[5] = reader.ReadBit();
        PlayerGUID[1] = reader.ReadBit();
        PlayerGUID[7] = reader.ReadBit();

        reader.ReadByteSeq(PlayerGUID, 2);
        reader.ReadByteSeq(PlayerGUID, 7);
        reader.ReadByteSeq(PlayerGUID, 0);
        reader.ReadByteSeq(PlayerGUID, 3);
        reader.ReadByteSeq(PlayerGUID, 5);
        reader.ReadByteSeq(PlayerGUID, 6);
        reader.ReadByteSeq(PlayerGUID, 1);
        reader.ReadByteSeq(PlayerGUID, 4);
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientPlayerLogin playerLogin = new (payload);
        Console.WriteLine($"Player {playerLogin.PlayerGUID} logging in.");

        Player player = new(playerLogin.PlayerGUID);
        player.MovementStatus.Position = new Vector3(-4025.6675f, -3915.7979f, 201.67465f);

        ServerLoginVerifiyWorld verifiyWorld = new()
        {
            MapID = 0,
            Position = player.MovementStatus.Position
        };

        session.EnqueuePacket(ref verifiyWorld);

        ServerTutorialFlags tutorialFlags = new();
        session.EnqueuePacket(ref tutorialFlags);

        ServerLoginSetTimeSpeed loginSetTimeSpeed = new()
        {
            GameTime = new WowTime(DateTimeOffset.Now).PackedTime
        };
        session.EnqueuePacket(ref loginSetTimeSpeed);

        ServerFeatureSystemStatus featureSystemStatus = new();
        session.EnqueuePacket(ref featureSystemStatus);

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

        return ValueTask.CompletedTask;
    }
}
