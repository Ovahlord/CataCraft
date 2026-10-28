using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemDamageRanged.dbc")]
public sealed class ItemDamageRangedEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(7)]
    public float[] Quality = new float[7];
    public int ItemLevel;
}
