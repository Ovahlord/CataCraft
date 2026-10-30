// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Entities.Object;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Unit;

public abstract class UnitBase : WorldObject
{
    // Properties
    public Stats Stats { get; }
    public Powers Powers { get; }
    public BaseAttackTime BaseAttackTime { get; }
    public MovementSpeed MovementSpeed { get; }
    public MovementSpeedMultiplier MovementSpeedMultiplier { get; }

    #region Update Field Accessors

    public uint BaseHealth
    {
        get => GetUInt32Value(EUnitFields.UNIT_FIELD_BASE_HEALTH);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_BASE_HEALTH, 0, value);
    }

    public uint MaxHealth
    {
        get => GetUInt32Value(EUnitFields.UNIT_FIELD_MAXHEALTH);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_MAXHEALTH, 0, value);
    }

    public uint Health
    {
        get => GetUInt32Value(EUnitFields.UNIT_FIELD_HEALTH);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_HEALTH, 0, value);
    }

    public int BaseMana
    {
        get => GetInt32Value(EUnitFields.UNIT_FIELD_BASE_MANA);
        set => SetInt32Value(EUnitFields.UNIT_FIELD_BASE_MANA, 0, value);
    }

    public float HoverHeight
    {
        get => GetFloatValue(EUnitFields.UNIT_FIELD_HOVERHEIGHT);
        set => SetFloatValue(EUnitFields.UNIT_FIELD_HOVERHEIGHT, 0, value);
    }

    public float CombatReach
    {
        get => GetFloatValue(EUnitFields.UNIT_FIELD_COMBATREACH);
        set => SetFloatValue(EUnitFields.UNIT_FIELD_COMBATREACH, 0, value);
    }

    public float BoundingRadius
    {
        get => GetFloatValue(EUnitFields.UNIT_FIELD_BOUNDINGRADIUS);
        set => SetFloatValue(EUnitFields.UNIT_FIELD_BOUNDINGRADIUS, 0, value);
    }

    public ChrRace Race
    {
        get => (ChrRace)GetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 0);
        set => SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 0, (byte)value);
    }

    public ChrClass Class
    {
        get => (ChrClass)GetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 1);
        set => SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 1, (byte)value);
    }


    public UnitSex Sex
    {
        get => (UnitSex)GetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 2);
        set => SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 3, (byte)value);
    }

    public PowerType DisplayPower
    {
        get => (PowerType)GetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 3);
        set => SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 3, (byte)value);
    }

    public byte Level
    {
        get => (byte)GetUInt32Value(EUnitFields.UNIT_FIELD_LEVEL, 0);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_LEVEL, 0, value);
    }

    public UnitFlags Flags
    {
        get => (UnitFlags)GetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS, 0);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS, 0, (uint)value);
    }

    public UnitFlags2 Flags2
    {
        get => (UnitFlags2)GetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS_2, 0);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS_2, 0, (uint)value);
    }

    public uint DisplayId
    {
        get => GetUInt32Value(EUnitFields.UNIT_FIELD_DISPLAYID);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_DISPLAYID, 0, value);
    }

    public uint NativeDisplayId
    {
        get => GetUInt32Value(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, 0, value);
    }

    public uint MountDisplayId
    {
        get => GetUInt32Value(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID, 0, value);
    }

    public uint FactionTemplateId
    {
        get => GetUInt32Value(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE);
        set => SetUInt32Value(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, 0, value);
    }

    #endregion // Update Field Accessors

    public UnitBase(WowGuid guid, int updateFieldCount, DataFieldVisibilityFlags[] updateFieldVisibilityFlags) : base(guid, updateFieldCount, updateFieldVisibilityFlags)
    {
        Stats = new Stats(this);
        Powers = new Powers(this);
        BaseAttackTime = new BaseAttackTime(this);
        MovementSpeed = new MovementSpeed(this);
        MovementSpeedMultiplier = new MovementSpeedMultiplier(this);

        ObjectType |= TypeMask.Unit;
    }
}
