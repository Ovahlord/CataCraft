using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTBaseMPByClass.dbc")]
public sealed class gtOCTBaseMPByClassEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
