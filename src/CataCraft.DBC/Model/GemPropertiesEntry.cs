using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GemProperties.dbc")]
public sealed class GemPropertiesEntry
{
    [Index(true)]
    public uint ID;
    public int EnchantID;
    public int MaxcountInv;
    public int MaxcountItem;
    public int Type;
    public int MinItemLevel;
}
