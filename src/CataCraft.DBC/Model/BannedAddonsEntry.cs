using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("BannedAddOns.dbc")]
public sealed class BannedAddonsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(4)]
    public int[] NameMD5 = new int[4];
    [Cardinality(4)]
    public int[] VersionMD5 = new int[4];
    public int LastModified;
    public int Flags;
}
