using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NamesProfanity.dbc")]
public sealed class NamesProfanityEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Language;
}
