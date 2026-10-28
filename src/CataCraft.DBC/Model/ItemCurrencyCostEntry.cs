using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemCurrencyCost.db2")]
public sealed class ItemCurrencyCostEntry
{
    [Index(true)]
    public uint ID;
    public int ItemID;
}
