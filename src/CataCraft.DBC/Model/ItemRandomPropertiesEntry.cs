using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemRandomProperties.dbc")]
public sealed class ItemRandomPropertiesEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    [Cardinality(5)]
    public int[] Enchantment = new int[5];
    public string Name2 = string.Empty;
}
