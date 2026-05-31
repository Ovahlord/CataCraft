// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.Entities.Unit;

public class Stats
{
    private readonly Stat[] _stats = new Stat[(int)UnitStats.Max];

    public Stats(Unit owner)
    {
        for (int i = 0; i < (int)UnitStats.Max; ++i)
        {
            _stats[i] = new Stat(owner, (UnitStats)i);
        }
    }

    public Stat this[UnitStats stat] => _stats[(int)stat];
}
