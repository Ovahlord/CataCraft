using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ImportPriceQuality.dbc")]
public sealed class ImportPriceQualityEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
