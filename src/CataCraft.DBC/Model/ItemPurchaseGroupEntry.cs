using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemPurchaseGroup.dbc")]
public sealed class ItemPurchaseGroupEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(8)]
    public int[] ItemID = new int[8];
    public string Name = string.Empty;
}
