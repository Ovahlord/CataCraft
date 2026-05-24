using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellIcon.dbc")]
public sealed class SpellIconEntry
{
    [Index(false)]
    public uint ID;
    public string TextureFilename = string.Empty;
}
