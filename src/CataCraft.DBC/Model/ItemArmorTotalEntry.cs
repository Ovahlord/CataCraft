using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemArmorTotal.dbc")]
public sealed class ItemArmorTotalEntry
{
    [Index(true)]
    public uint ID;
    public int ItemLevel;
    public float Cloth;
    public float Leather;
    public float Mail;
    public float Plate;
}
