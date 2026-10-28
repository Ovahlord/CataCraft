using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ZoneLightPoint.dbc")]
public sealed class ZoneLightPointEntry
{
    [Index(true)]
    public uint ID;
    public int ZoneLightID;
    [Cardinality(2)]
    public float[] Pos = new float[2];
    public int PointOrder;
}
