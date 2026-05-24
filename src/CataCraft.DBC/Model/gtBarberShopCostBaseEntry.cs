using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtBarberShopCostBase.dbc")]
public sealed class gtBarberShopCostBaseEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
