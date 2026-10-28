using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemGroupSounds.dbc")]
public sealed class ItemGroupSoundsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(4)]
    public int[] Sound = new int[4];
}
