using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtChanceToSpellCritBase.dbc")]
public sealed class gtChanceToSpellCritBaseEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
