using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemDamageTwoHandCaster.dbc")]
public sealed class ItemDamageTwoHandCasterEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(7)]
    public float[] Quality = new float[7];
    public int ItemLevel;
}
