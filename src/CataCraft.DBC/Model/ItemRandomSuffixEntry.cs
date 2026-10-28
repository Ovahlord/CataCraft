using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemRandomSuffix.dbc")]
public sealed class ItemRandomSuffixEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public string InternalName = string.Empty;
    [Cardinality(5)]
    public int[] Enchantment = new int[5];
    [Cardinality(5)]
    public int[] AllocationPct = new int[5];
}
