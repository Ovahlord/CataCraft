using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ImportPriceWeapon.dbc")]
public sealed class ImportPriceWeaponEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
