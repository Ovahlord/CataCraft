// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Unit;

public class BaseAttackTime
{
    // Constants
    public uint DefaultBaseAttackTime { get; private set; } = 2000;

    // Fields
    private readonly UnitBase _owner;

    public BaseAttackTime(UnitBase owner)
    {
        _owner = owner;
        this[BaseAttackType.MainHand] = DefaultBaseAttackTime;
        this[BaseAttackType.OffHand] = DefaultBaseAttackTime;
    }

    public uint this[BaseAttackType index]
    {
        get => _owner.GetUInt32Value(EUnitFields.UNIT_FIELD_BASEATTACKTIME, (int)index);
        set => _owner.SetUInt32Value(EUnitFields.UNIT_FIELD_BASEATTACKTIME, (int)index, value);
    }
}
