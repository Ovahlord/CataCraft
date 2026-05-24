using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MountType.dbc")]
public sealed class MountTypeEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(24)]
    public int[] Capability = new int[24];
}
