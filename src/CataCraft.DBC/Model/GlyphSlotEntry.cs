using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GlyphSlot.dbc")]
public sealed class GlyphSlotEntry
{
    [Index(false)]
    public uint ID;
    public int Type;
    public int Tooltip;
}
