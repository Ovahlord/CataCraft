using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemVisuals.dbc")]
public sealed class ItemVisualsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(5)]
    public int[] Slot = new int[5];
}
