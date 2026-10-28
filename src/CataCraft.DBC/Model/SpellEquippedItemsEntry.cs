using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellEquippedItems.dbc")]
public sealed class SpellEquippedItemsEntry
{
    [Index(true)]
    public uint ID;
    public int EquippedItemClass;
    public int EquippedItemInvTypes;
    public int EquippedItemSubclass;
}
