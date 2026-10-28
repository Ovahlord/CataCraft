using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellIcon.dbc")]
public sealed class SpellIconEntry
{
    [Index(true)]
    public uint ID;
    public string TextureFilename = string.Empty;
}
