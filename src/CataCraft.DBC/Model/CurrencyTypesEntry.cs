using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CurrencyTypes.dbc")]
public sealed class CurrencyTypesEntry
{
    [Index(false)]
    public uint ID;
    public int CategoryID;
    public string Name = string.Empty;
    [Cardinality(2)]
    public string[] InventoryIcon = new string[2];
    public int SpellWeight;
    public int SpellCategory;
    public int MaxQty;
    public int MaxEarnablePerWeek;
    public int Flags;
    public string Description = string.Empty;
}
