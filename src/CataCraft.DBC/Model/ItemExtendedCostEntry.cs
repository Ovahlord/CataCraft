using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemExtendedCost.db2")]
public sealed class ItemExtendedCostEntry
{
    [Index(false)]
    public uint ID;
    public int HonorPoints;
    public int RequiredArenaRating;
    public int ArenaBracket;
    [Cardinality(5)]
    public int[] ItemID = new int[5];
    [Cardinality(5)]
    public int[] ItemCount = new int[5];
    public int ArenaPoints;
    public int ItemPurchaseGroup;
    [Cardinality(5)]
    public int[] CurrencyID = new int[5];
    [Cardinality(5)]
    public int[] CurrencyCount = new int[5];
    public int MinFactionID;
    public int MinReputation;
    public int Flags;
    public int RequiredGuildLevel;
    public int RequiredAchievement;
}
