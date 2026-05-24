using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellDuration.dbc")]
public sealed class SpellDurationEntry
{
    [Index(false)]
    public uint ID;
    public int Duration;
    public int DurationPerLevel;
    public int MaxDuration;
}
