using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTRegenMP.dbc")]
public sealed class gtOCTRegenMPEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
