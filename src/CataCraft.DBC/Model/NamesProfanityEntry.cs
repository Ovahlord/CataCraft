using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NamesProfanity.dbc")]
public sealed class NamesProfanityEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Language;
}
