using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TransportAnimation.dbc")]
public sealed class TransportAnimationEntry
{
    [Index(true)]
    public uint ID;
    public int TransportID;
    public int TimeIndex;
    [Cardinality(3)]
    public float[] Pos = new float[3];
    public int SequenceID;
}
