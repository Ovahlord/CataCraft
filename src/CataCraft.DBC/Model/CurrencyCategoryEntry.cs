using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CurrencyCategory.dbc")]
public sealed class CurrencyCategoryEntry
{
    [Index(true)]
    public uint ID;
    public int Flags;
    public string Name = string.Empty;
}
