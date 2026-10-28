using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("RandPropPoints.dbc")]
public sealed class RandPropPointsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(5)]
    public int[] Epic = new int[5];
    [Cardinality(5)]
    public int[] Superior = new int[5];
    [Cardinality(5)]
    public int[] Good = new int[5];
}
