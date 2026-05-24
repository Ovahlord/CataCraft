using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellEquippedItems.dbc")]
public sealed class SpellEquippedItemsEntry
{
    [Index(false)]
    public uint ID;
    public int EquippedItemClass;
    public int EquippedItemInvTypes;
    public int EquippedItemSubclass;
}
