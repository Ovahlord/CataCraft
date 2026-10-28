using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GlyphSlot.dbc")]
public sealed class GlyphSlotEntry
{
    [Index(true)]
    public uint ID;
    public int Type;
    public int Tooltip;
}
