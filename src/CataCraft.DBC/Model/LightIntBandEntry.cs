using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LightIntBand.dbc")]
public sealed class LightIntBandEntry
{
    [Index(false)]
    public uint ID;
    public int Num;
    [Cardinality(16)]
    public int[] Time = new int[16];
    [Cardinality(16)]
    public int[] Data = new int[16];
}
