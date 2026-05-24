using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtChanceToSpellCritBase.dbc")]
public sealed class gtChanceToSpellCritBaseEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
