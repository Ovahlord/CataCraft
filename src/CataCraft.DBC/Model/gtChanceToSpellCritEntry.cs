using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtChanceToSpellCrit.dbc")]
public sealed class gtChanceToSpellCritEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
