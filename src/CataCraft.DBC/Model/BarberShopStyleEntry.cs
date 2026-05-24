using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("BarberShopStyle.dbc")]
public sealed class BarberShopStyleEntry
{
    [Index(false)]
    public uint ID;
    public int Type;
    public string DisplayName = string.Empty;
    public string Description = string.Empty;
    public float CostModifier;
    public int Race;
    public int Sex;
    public int Data;
}
