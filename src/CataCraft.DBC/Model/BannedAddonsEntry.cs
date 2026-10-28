using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("BannedAddOns.dbc")]
public sealed class BannedAddonsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(4)]
    public int[] NameMD5 = new int[4];
    [Cardinality(4)]
    public int[] VersionMD5 = new int[4];
    public int LastModified;
    public int Flags;
}
