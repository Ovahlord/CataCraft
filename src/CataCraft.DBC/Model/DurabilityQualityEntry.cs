using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DurabilityQuality.dbc")]
public sealed class DurabilityQualityEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
