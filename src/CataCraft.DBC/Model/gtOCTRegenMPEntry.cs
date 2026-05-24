using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTRegenMP.dbc")]
public sealed class gtOCTRegenMPEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
