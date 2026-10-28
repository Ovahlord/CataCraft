using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureType.dbc")]
public sealed class CreatureTypeEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
}
