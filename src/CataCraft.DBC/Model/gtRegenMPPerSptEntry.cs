using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtRegenMPPerSpt.dbc")]
public sealed class gtRegenMPPerSptEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
