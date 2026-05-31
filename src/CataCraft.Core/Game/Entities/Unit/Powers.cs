// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.DBC;
using CataCraft.DBC.Model;

namespace CataCraft.Core.Game.Entities.Unit;

public class Powers
{
    private readonly Dictionary<UnitPowerType, Power> _powers = [];
    private Unit _owner;

    public Powers(Unit owner)
    {
        _owner = owner;
    }

    public Power? this[UnitPowerType index] => _powers.TryGetValue(index, out Power? power) ? power : null;

    public void Initialize()
    {
        IEnumerable<ChrClassesXPowerTypesEntry> entries = DBCManager.SChrClassesXPowerTypesStore.Values
            .Where(cp => cp.ClassID == (int)_owner.Class)
            .OrderBy(cp => cp.ID);

        int powerIndex = 0;
        foreach (ChrClassesXPowerTypesEntry entry in entries)
        {
            _powers.TryAdd((UnitPowerType)entry.PowerType, new Power(_owner, powerIndex, (UnitPowerType)entry.PowerType));
            if (powerIndex == 0)
                _owner.PowerType = (UnitPowerType)entry.PowerType;

            ++powerIndex;
        }
    }
}
