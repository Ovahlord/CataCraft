using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemPriceBase.dbc")]
public sealed class ItemPriceBaseEntry
{
    [Index(false)]
    public uint ID;
    public int ItemLevel;
    public float Armor;
    public float Weapon;
}
