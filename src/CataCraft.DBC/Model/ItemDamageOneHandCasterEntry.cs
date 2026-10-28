using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemDamageOneHandCaster.dbc")]
public sealed class ItemDamageOneHandCasterEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(7)]
    public float[] Quality = new float[7];
    public int ItemLevel;
}
