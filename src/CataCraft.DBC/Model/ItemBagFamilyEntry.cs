using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemBagFamily.dbc")]
public sealed class ItemBagFamilyEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
