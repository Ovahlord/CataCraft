using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemReforge.dbc")]
public sealed class ItemReforgeEntry
{
    [Index(false)]
    public uint ID;
    public int SourceStat;
    public float SourceMultiplier;
    public int TargetStat;
    public float TargetMultiplier;
}
