using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTBaseMPByClass.dbc")]
public sealed class gtOCTBaseMPByClassEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
