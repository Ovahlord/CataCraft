using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellCastTimes.dbc")]
public sealed class SpellCastTimesEntry
{
    [Index(false)]
    public uint ID;
    public int Base;
    public int PerLevel;
    public int Minimum;
}
