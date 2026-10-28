using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ImportPriceQuality.dbc")]
public sealed class ImportPriceQualityEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
