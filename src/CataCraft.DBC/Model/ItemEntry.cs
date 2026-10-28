using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Item.db2")]
public sealed class ItemEntry
{
    [Index(true)]
    public uint ID;
    public int ClassID;
    public int SubclassID;
    public int SoundOverrideSubclassID;
    public int Material;
    public int DisplayInfoID;
    public int InventoryType;
    public int SheatheType;
}
