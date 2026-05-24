using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemLimitCategory.dbc")]
public sealed class ItemLimitCategoryEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Quantity;
    public int Flags;
}
