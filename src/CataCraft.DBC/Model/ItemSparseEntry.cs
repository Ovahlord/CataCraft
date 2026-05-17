using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Item-sparse.db2")]
public sealed class ItemSparseEntry
{
    [Index(true)]
    public uint ID;
    public uint Quality;
    [Cardinality(2)]
    public uint[] Flags = new uint[2];
    public float PriceRandomValue;
    public float PriceVariance;
    public uint BuyCount;
    public uint BuyPrice;
    public uint SellPrice;
    public uint InventoryType;
    public int AllowableClass;
    public int AllowableRace;
    public uint ItemLevel;
    public uint RequiredLevel;
    public uint RequiredSkill;
    public uint RequiredSkillRank;
    public int RequiredSpell;
    public uint RequiredHonorRank;
    public uint RequiredCityRank;
    public uint RequiredReputationFaction;
    public uint RequiredReputationRank;
    public int MaxCount;
    public int Stackable;
    public uint ContainerSlots;
    [Cardinality(10)]
    public int[] ItemStatType = new int[10];
    [Cardinality(10)]
    public int[] ItemStatValue = new int[10];
    [Cardinality(10)]
    public int[] ItemStatAllocation = new int[10];
    [Cardinality(10)]
    public int[] ItemStatSocketCostMultiplier = new int[10];
    public int ScalingStatDistribution;
    public int DamageType;
    public uint Delay;
    public float RangedModRange;
    [Cardinality(5)]
    public int[] SpellID = new int[5];
    [Cardinality(5)]
    public int[] SpellTrigger = new int[5];
    [Cardinality(5)]
    public int[] SpellCharges = new int[5];
    [Cardinality(5)]
    public int[] SpellCooldown = new int[5];
    [Cardinality(5)]
    public int[] SpellCategory = new int[5];
    [Cardinality(5)]
    public int[] SpellCategoryCooldown = new int[5];
    public int Bonding;
    public string Display = string.Empty;
    public string Display1 = string.Empty;
    public string Display2 = string.Empty;
    public string Display3 = string.Empty;
    public string Description = string.Empty;
    public uint PageText;
    public int LanguageID;
    public int PageMaterial;
    public int StartQuest;
    public uint LockID;
    public int Material;
    public int SheatheType;
    public int RandomProperty;
    public uint RandomSuffix;
    public uint ItemSet;
    public uint AreaID;
    public int MapID;
    public int BagFamily;
    public int TotemCategory;
    [Cardinality(3)]
    public int[] SocketColor = new int[3];
    [Cardinality(3)]
    public uint[] Content = new uint[3];
    public int SocketBonus;
    public int GemProperties;
    public float ArmorDamageModifier;
    public int Duration;
    public uint ItemLimitCategory;
    public int HolidayID;
    public float StatScalingFactor;
    public int CurrencySubstitutionID;
    public int CurrencySubstitutionCount;
}
