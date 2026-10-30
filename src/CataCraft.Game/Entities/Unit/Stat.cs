// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Unit;

public class Stat
{
    // Fields
    private readonly UnitBase _owner;
    private readonly UnitStats _stat;

    public Stat(UnitBase owner, UnitStats stat)
    {
        _owner = owner;
        _stat = stat;
    }

    public uint this[UnitStats stat]
    {
        get => _owner.GetUInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)stat);
        set => _owner.SetUInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)stat, value);
    }

    public int BaseValue
    {
        get => _owner.GetInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)_stat);
        set => _owner.SetInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)_stat, value);
    }

    public int PositiveStat
    {
        get => _owner.GetInt32Value(EUnitFields.UNIT_FIELD_POSSTAT0, (int)_stat);
        set => _owner.SetInt32Value(EUnitFields.UNIT_FIELD_POSSTAT0, (int)_stat, value);
    }

    public int NegativeStat
    {
        get => _owner.GetInt32Value(EUnitFields.UNIT_FIELD_NEGSTAT0, (int)_stat);
        set => _owner.SetInt32Value(EUnitFields.UNIT_FIELD_NEGSTAT0, (int)_stat, value);
    }

    public int Value => BaseValue + PositiveStat + NegativeStat;
}
