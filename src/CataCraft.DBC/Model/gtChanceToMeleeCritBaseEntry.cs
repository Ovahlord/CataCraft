using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtChanceToMeleeCritBase.dbc")]
public sealed class gtChanceToMeleeCritBaseEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
