using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemDamageTwoHand.dbc")]
public sealed class ItemDamageTwoHandEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(7)]
    public float[] Quality = new float[7];
    public int ItemLevel;
}
