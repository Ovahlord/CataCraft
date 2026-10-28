using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellDuration.dbc")]
public sealed class SpellDurationEntry
{
    [Index(true)]
    public uint ID;
    public int Duration;
    public int DurationPerLevel;
    public int MaxDuration;
}
