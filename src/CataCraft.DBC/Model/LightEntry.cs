using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Light.dbc")]
public sealed class LightEntry
{
    [Index(true)]
    public uint ID;
    public int ContinentID;
    [Cardinality(3)]
    public float[] GameCoords = new float[3];
    public float GameFalloffStart;
    public float GameFalloffEnd;
    [Cardinality(8)]
    public int[] LightParamsID = new int[8];
}
