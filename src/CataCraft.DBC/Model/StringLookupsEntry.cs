using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("StringLookups.dbc")]
public sealed class StringLookupsEntry
{
    [Index(true)]
    public uint ID;
    public string String = string.Empty;
}
