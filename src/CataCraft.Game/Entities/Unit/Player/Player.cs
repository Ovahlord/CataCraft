// This file is part of the CataCraft project, which is published under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using CataCraft.Database.Realm.Model;
using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;

namespace CataCraft.Game.Entities.Unit.Player;

public sealed class Player : UnitBase
{
    // Properties
    public GameSession? Session { get; set; }
    public List<WowObject> NewObjects { get; } = [];
    public List<WowObject> OutOfRangeObjects { get; } = [];
    public List<WowObject> VisibleObjects { get; } = [];

    #region Update Field Accessors

    public byte SkinId
    {
        get => GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 0);
        set => SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 0, value);
    }

    public byte FaceId
    {
        get => GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 1);
        set => SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 1, value);
    }

    public byte HairStyleId
    {
        get => GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 2);
        set => SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 2, value);
    }

    public byte HairColorId
    {
        get => GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 3);
        set => SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 3, value);
    }

    public byte FacialHairStyleId
    {
        get => GetUInt8Value(EPlayerFields.PLAYER_BYTES_2, 0, 0);
        set => SetUInt8Value(EPlayerFields.PLAYER_BYTES_2, 0, 0, value);
    }

    public UnitSex PlayerSex
    {
        get => (UnitSex)GetUInt8Value(EPlayerFields.PLAYER_BYTES_3, 0, 0);
        set => SetUInt8Value(EPlayerFields.PLAYER_BYTES_3, 0, 0, (byte)value);
    }

    public byte MaxLevel
    {
        get => (byte)GetUInt32Value(EPlayerFields.PLAYER_FIELD_MAX_LEVEL, 0);
        set => SetUInt32Value(EPlayerFields.PLAYER_FIELD_MAX_LEVEL, 0, value);
    }

    #endregion // Update Field accessors

    public Player(WowGuid guid) : base(guid, (int)EPlayerFields.PLAYER_END, UpdateFieldConstants.SPlayerVisibilityFlags)
    {
        ObjectType |= TypeMask.Player;
    }

    public static bool TryCreatePlayerFromData(Character characterDbData, [NotNullWhen(true)] out Player? player)
    {
        if (characterDbData.Stats == null)
        {
            player = null;
            return false;
        }

        if (!DBCManager.SChrRacesStore.TryGetValue(characterDbData.RaceId, out ChrRacesEntry? race))
        {
            player = null;
            return false;
        }

        player = new(new WowGuid(WowGuidType.Player, (uint)characterDbData.Id))
        {
            Sex = (UnitSex)characterDbData.SexId, PlayerSex = (UnitSex)characterDbData.SexId, FaceId = characterDbData.FaceId,
            SkinId = characterDbData.SkinId,
            HairStyleId = characterDbData.HairStyleId,
            HairColorId = characterDbData.HairColorId,
            FacialHairStyleId = characterDbData.FacialHairStyleId,
            Level = characterDbData.Stats.ExperienceLevel,
            MaxLevel = 85,
            Race = (ChrRace)characterDbData.RaceId,
            Class = (ChrClass)characterDbData.ClassId,
            Flags = UnitFlags.PlayerControlled,
            Flags2 = UnitFlags2.RegeneratePower,
            MaxHealth = 100,
            Health = 100,
            BoundingRadius = 1f,
            CombatReach = 1f,
            HoverHeight = 1f
        };

        player.SetInt32Value(EPlayerFields.PLAYER_FIELD_WATCHED_FACTION_INDEX, 0, -1);
        player.MovementStatus.Position = new Vector3(characterDbData.Stats.PositionX, characterDbData.Stats.PositionY, characterDbData.Stats.PositionZ);
        player.MovementStatus.Facing = characterDbData.Stats.Facing;

        // The player can always see himself
        player.NewObjects.Add(player);

        player.FactionTemplateId = (uint)race.FactionID;
        if (player.Sex == UnitSex.Male)
        {
            player.DisplayId = (uint)race.MaleDisplayID;
            player.NativeDisplayId = (uint)race.MaleDisplayID;
        }
        else
        {
            player.DisplayId = (uint)race.FemaleDisplayID;
            player.NativeDisplayId = (uint)race.FemaleDisplayID;
        }

        player.Powers.Initialize();
        return true;
    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }
}
