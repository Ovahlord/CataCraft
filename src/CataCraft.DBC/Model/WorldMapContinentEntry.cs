using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldMapContinent.dbc")]
public sealed class WorldMapContinentEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int LeftBoundary;
    public int RightBoundary;
    public int TopBoundary;
    public int BottomBoundary;
    [Cardinality(2)]
    public float[] ContinentOffset = new float[2];
    public float Scale;
    [Cardinality(2)]
    public float[] TaxiMin = new float[2];
    [Cardinality(2)]
    public float[] TaxiMax = new float[2];
    public int WorldMapID;
}
