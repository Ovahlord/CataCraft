using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MountType.dbc")]
public sealed class MountTypeEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(24)]
    public int[] Capability = new int[24];
}
