using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemArmorShield.dbc")]
public sealed class ItemArmorShieldEntry
{
    [Index(true)]
    public uint ID;
    public int ItemLevel;
    [Cardinality(7)]
    public float[] Quality = new float[7];
}
