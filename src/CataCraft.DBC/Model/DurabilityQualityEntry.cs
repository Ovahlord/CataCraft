using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DurabilityQuality.dbc")]
public sealed class DurabilityQualityEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
