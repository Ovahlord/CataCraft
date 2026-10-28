using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("BankBagSlotPrices.dbc")]
public sealed class BankBagSlotPricesEntry
{
    [Index(true)]
    public uint ID;
    public int Cost;
}
