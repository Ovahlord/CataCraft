using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("RandPropPoints.dbc")]
public sealed class RandPropPointsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(5)]
    public int[] Epic = new int[5];
    [Cardinality(5)]
    public int[] Superior = new int[5];
    [Cardinality(5)]
    public int[] Good = new int[5];
}
