using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtChanceToMeleeCrit.dbc")]
public sealed class gtChanceToMeleeCritEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
