using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Lock.dbc")]
public sealed class LockEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(8)]
    public int[] Type = new int[8];
    [Cardinality(8)]
    public int[] Index = new int[8];
    [Cardinality(8)]
    public int[] Skill = new int[8];
    [Cardinality(8)]
    public int[] Action = new int[8];
}
