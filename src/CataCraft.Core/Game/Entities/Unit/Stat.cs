// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.Entities.Unit;

public class Stat
{
    // Fields
    private readonly Unit _owner;
    private readonly UnitStats _stat;

    public Stat(Unit owner, UnitStats stat)
    {
        _owner = owner;
        _stat = stat;
    }

    public uint this[UnitStats stat]
    {
        get => _owner.DataFields.GetUInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)stat);
        set => _owner.DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)stat, value);
    }

    public int BaseValue
    {
        get => _owner.DataFields.GetInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)_stat);
        set => _owner.DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_STAT0, (int)_stat, value);
    }

    public int PositiveStat
    {
        get => _owner.DataFields.GetInt32Value(EUnitFields.UNIT_FIELD_POSSTAT0, (int)_stat);
        set => _owner.DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_POSSTAT0, (int)_stat, value);
    }

    public int NegativeStat
    {
        get => _owner.DataFields.GetInt32Value(EUnitFields.UNIT_FIELD_NEGSTAT0, (int)_stat);
        set => _owner.DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_NEGSTAT0, (int)_stat, value);
    }

    public int Value => BaseValue + PositiveStat + NegativeStat;
}
