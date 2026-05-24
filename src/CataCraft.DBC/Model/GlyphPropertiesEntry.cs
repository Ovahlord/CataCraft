using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GlyphProperties.dbc")]
public sealed class GlyphPropertiesEntry
{
    [Index(false)]
    public uint ID;
    public int SpellID;
    public int GlyphSlotFlags;
    public int SpellIconID;
}
