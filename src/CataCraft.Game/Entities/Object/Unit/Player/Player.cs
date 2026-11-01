// This file is part of the CataCraft project, which is published under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using CataCraft.Database.Realm.Entities;
using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;

namespace CataCraft.Game.Entities.Object.Unit.Player;

public sealed class Player : Unit
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

    public void InitializeFromData(Character characterDbData)
    {
        if (characterDbData.Stats == null)
            throw new NullReferenceException(nameof(characterDbData.Stats));

        if (!DBCManager.SChrRacesStore.TryGetValue(characterDbData.RaceId, out ChrRacesEntry? race))
            throw new NullReferenceException($"No record found in ChrRaces.dbc for RaceId {characterDbData.RaceId}");

        Sex = (UnitSex)characterDbData.SexId;
        PlayerSex = (UnitSex)characterDbData.SexId;
        FaceId = characterDbData.FaceId;
        SkinId = characterDbData.SkinId;
        HairStyleId = characterDbData.HairStyleId;
        HairColorId = characterDbData.HairColorId;
        FacialHairStyleId = characterDbData.FacialHairStyleId;
        Level = characterDbData.Stats.ExperienceLevel;
        MaxLevel = 85;
        Race = (ChrRace)characterDbData.RaceId;
        Class = (ChrClass)characterDbData.ClassId;
        Flags = UnitFlags.PlayerControlled;
        Flags2 = UnitFlags2.RegeneratePower;
        MaxHealth = 100;
        Health = 100;
        BoundingRadius = 1f;
        CombatReach = 1f;
        HoverHeight = 1f;

        SetInt32Value(EPlayerFields.PLAYER_FIELD_WATCHED_FACTION_INDEX, 0, -1);
        MovementStatus.Position = new Vector3(characterDbData.Stats.PositionX, characterDbData.Stats.PositionY, characterDbData.Stats.PositionZ);
        MovementStatus.Facing = characterDbData.Stats.Facing;

        // The player can always see himself
        NewObjects.Add(this);

        FactionTemplateId = (uint)race.FactionID;
        if (Sex == UnitSex.Male)
        {
            DisplayId = (uint)race.MaleDisplayID;
            NativeDisplayId = (uint)race.MaleDisplayID;
        }
        else
        {
            DisplayId = (uint)race.FemaleDisplayID;
            NativeDisplayId = (uint)race.FemaleDisplayID;
        }

        Powers.Initialize();
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


        return true;
    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }
}
