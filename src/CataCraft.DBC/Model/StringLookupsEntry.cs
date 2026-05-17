using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("StringLookups.dbc")]
public sealed class StringLookupsEntry
{
    [Index(true)]
    public uint ID;
    public string String = string.Empty;
}
