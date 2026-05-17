// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;

namespace CataCraft.Core.Game.World.Entities.Unit;

public class Unit : WowObject
{
    public override bool IsWorldObject => true;
    public Stats Stats { get; private set; } = new();

    public Unit(WowGuid guid) : base(guid)
    {
    }

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

    #endregion // DataField accessors

    public void SetBaseAttackTime(int time) => DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_BASEATTACKTIME, 0, time);
}
