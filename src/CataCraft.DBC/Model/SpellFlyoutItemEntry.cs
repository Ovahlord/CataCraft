using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellFlyoutItem.dbc")]
public sealed class SpellFlyoutItemEntry
{
    [Index(false)]
    public uint ID;
    public int SpellFlyoutID;
    public int SpellID;
    public int Slot;
}
