using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AttackAnimTypes.dbc")]
public sealed class AttackAnimTypesEntry
{
    public int AnimID;
    public string AnimName = string.Empty;
}
