using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LightFloatBand.dbc")]
public sealed class LightFloatBandEntry
{
    [Index(true)]
    public uint ID;
    public int Num;
    [Cardinality(16)]
    public int[] Time = new int[16];
    [Cardinality(16)]
    public float[] Data = new float[16];
}
