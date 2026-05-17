using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTBaseHPByClass.dbc")]
public sealed class gtOCTBaseHPByClassEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
