using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellFlyoutItem.dbc")]
public sealed class SpellFlyoutItemEntry
{
    [Index(true)]
    public uint ID;
    public int SpellFlyoutID;
    public int SpellID;
    public int Slot;
}
