using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemLimitCategory.dbc")]
public sealed class ItemLimitCategoryEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Quantity;
    public int Flags;
}
