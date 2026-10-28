using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtBarberShopCostBase.dbc")]
public sealed class gtBarberShopCostBaseEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
