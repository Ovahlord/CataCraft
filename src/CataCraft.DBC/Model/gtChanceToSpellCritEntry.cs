using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtChanceToSpellCrit.dbc")]
public sealed class gtChanceToSpellCritEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
