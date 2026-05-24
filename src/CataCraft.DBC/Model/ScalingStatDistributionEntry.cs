using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ScalingStatDistribution.dbc")]
public sealed class ScalingStatDistributionEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(10)]
    public int[] StatID = new int[10];
    [Cardinality(10)]
    public int[] Bonus = new int[10];
    public int Minlevel;
    public int Maxlevel;
}
