// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Unit;

public sealed class Powers
{
    private readonly Dictionary<PowerType, Power> _powers = [];
    private readonly Unit _owner;

    public Powers(Unit owner)
    {
        _owner = owner;
    }

    public Power? this[PowerType index] => _powers.TryGetValue(index, out Power? power) ? power : null;

    public void Initialize()
    {
        IEnumerable<ChrClassesXPowerTypesEntry> entries = DBCManager.SChrClassesXPowerTypesStore.Values
            .Where(cp => cp.ClassID == (int)_owner.Class)
            .OrderBy(cp => cp.ID);

        int powerIndex = 0;
        foreach (ChrClassesXPowerTypesEntry entry in entries)
        {
            PowerType powerType = (PowerType)entry.PowerType;
            if (_owner.Guid.IsUnit && !Power.IsUsedByNpcs(powerType))
                continue;

            _powers.TryAdd(powerType, new Power(_owner, powerIndex, powerType));
            if (powerIndex == 0)
                _owner.DisplayPower = powerType;

            ++powerIndex;
        }
    }


}
