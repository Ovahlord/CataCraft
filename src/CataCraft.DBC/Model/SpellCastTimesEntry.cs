using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellCastTimes.dbc")]
public sealed class SpellCastTimesEntry
{
    [Index(true)]
    public uint ID;
    public int Base;
    public int PerLevel;
    public int Minimum;
}
