using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AttackAnimTypes.dbc")]
public sealed class AttackAnimTypesEntry
{
    [Index(true)]
    public int AnimID;
    public string AnimName = string.Empty;
}
