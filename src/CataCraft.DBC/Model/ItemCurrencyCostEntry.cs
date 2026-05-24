using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemCurrencyCost.db2")]
public sealed class ItemCurrencyCostEntry
{
    [Index(false)]
    public uint ID;
    public int ItemID;
}
