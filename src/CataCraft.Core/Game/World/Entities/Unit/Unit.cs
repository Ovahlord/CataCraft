// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;

namespace CataCraft.Core.Game.World.Entities.Unit;

public class Unit : WowObject
{
    public override bool IsWorldObject => true;
    public Stats Stats { get; private set; } = new();

    #region DataField accessors

    public uint BaseHealth
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_BASE_HEALTH);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_BASE_HEALTH, 0, value);
    }

    public uint MaxHealth
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_MAXHEALTH);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_MAXHEALTH, 0, value);
    }

    public uint Health
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_HEALTH);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_HEALTH, 0, value);
    }

    public uint BaseMana
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_BASE_MANA);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_BASE_MANA, 0, value);
    }

    public float HoverHeight
    {
        get => DataFields.GetFloatValue(EUnitFields.UNIT_FIELD_HOVERHEIGHT);
        set => DataFields.SetFloatValue(EUnitFields.UNIT_FIELD_HOVERHEIGHT, 0, value);
    }

    public float CombatReach
    {
        get => DataFields.GetFloatValue(EUnitFields.UNIT_FIELD_COMBATREACH);
        set => DataFields.SetFloatValue(EUnitFields.UNIT_FIELD_COMBATREACH, 0, value);
    }

    public float BoundingRadius
    {
        get => DataFields.GetFloatValue(EUnitFields.UNIT_FIELD_BOUNDINGRADIUS);
        set => DataFields.SetFloatValue(EUnitFields.UNIT_FIELD_BOUNDINGRADIUS, 0, value);
    }

    public ChrRace Race
    {
        get => (ChrRace)DataFields.GetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 0);
        set => DataFields.SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 0, (byte)value);
    }

    public UnitClass Class
    {
        get => (UnitClass)DataFields.GetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 1);
        set => DataFields.SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 1, (byte)value);
    }

    public UnitSex Sex
    {
        get => (UnitSex)DataFields.GetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 3);
        set => DataFields.SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 3, (byte)value);
    }

    public byte Level
    {
        get => (byte)DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_LEVEL, 0);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_LEVEL, 0, value);
    }

    public UnitFlags Flags
    {
        get => (UnitFlags)DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS, 0);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS, 0, (uint)value);
    }

    public UnitFlags2 Flags2
    {
        get => (UnitFlags2)DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS_2, 0);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_FLAGS_2, 0, (uint)value);
    }

    public uint DisplayId
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_DISPLAYID);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_DISPLAYID, 0, value);
    }

    public uint NativeDisplayId
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, 0, value);
    }

    public uint MountDisplayId
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID, 0, value);
    }

    public uint FactionTemplateId
    {
        get => DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE);
        set => DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, 0, value);
    }

    public void SetBaseAttackTime(int time) => DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_BASEATTACKTIME, 0, time);

    #endregion // DataField accessors

    public Unit(WowGuid guid) : base(guid)
    {
    }
}
