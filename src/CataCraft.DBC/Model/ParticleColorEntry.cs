using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ParticleColor.dbc")]
public sealed class ParticleColorEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(3)]
    public int[] Start = new int[3];
    [Cardinality(3)]
    public int[] MID = new int[3];
    [Cardinality(3)]
    public int[] End = new int[3];
}
