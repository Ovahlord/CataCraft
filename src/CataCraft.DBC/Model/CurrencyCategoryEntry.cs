using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CurrencyCategory.dbc")]
public sealed class CurrencyCategoryEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public string Name = string.Empty;
}
