using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PlayerCondition.dbc")]
public sealed class PlayerConditionEntry
{
    [Index(false)]
    public uint ID;
    public string FailureDescription = string.Empty;
}
