using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemGroupSounds.dbc")]
public sealed class ItemGroupSoundsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(4)]
    public int[] Sound = new int[4];
}
