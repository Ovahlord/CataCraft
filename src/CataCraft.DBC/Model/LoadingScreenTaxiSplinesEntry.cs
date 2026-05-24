using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LoadingScreenTaxiSplines.dbc")]
public sealed class LoadingScreenTaxiSplinesEntry
{
    [Index(false)]
    public uint ID;
    public int PathID;
    [Cardinality(8)]
    public float[] Locx = new float[8];
    [Cardinality(8)]
    public float[] Locy = new float[8];
    public int LegIndex;
}
