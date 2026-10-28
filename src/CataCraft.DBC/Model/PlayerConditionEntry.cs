using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PlayerCondition.dbc")]
public sealed class PlayerConditionEntry
{
    [Index(true)]
    public uint ID;
    public string FailureDescription = string.Empty;
}
