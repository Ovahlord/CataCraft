using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemReforge.dbc")]
public sealed class ItemReforgeEntry
{
    [Index(true)]
    public uint ID;
    public int SourceStat;
    public float SourceMultiplier;
    public int TargetStat;
    public float TargetMultiplier;
}
