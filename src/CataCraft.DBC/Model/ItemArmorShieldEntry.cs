using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemArmorShield.dbc")]
public sealed class ItemArmorShieldEntry
{
    [Index(false)]
    public uint ID;
    public int ItemLevel;
    [Cardinality(7)]
    public float[] Quality = new float[7];
}
