using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtChanceToMeleeCrit.dbc")]
public sealed class gtChanceToMeleeCritEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
