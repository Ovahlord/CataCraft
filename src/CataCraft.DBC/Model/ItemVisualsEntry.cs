using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemVisuals.dbc")]
public sealed class ItemVisualsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(5)]
    public int[] Slot = new int[5];
}
