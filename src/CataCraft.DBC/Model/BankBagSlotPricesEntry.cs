using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("BankBagSlotPrices.dbc")]
public sealed class BankBagSlotPricesEntry
{
    [Index(false)]
    public uint ID;
    public int Cost;
}
