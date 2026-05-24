using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaPOI.dbc")]
public sealed class AreaPOIEntry
{
    [Index(false)]
    public uint ID;
    public int Importance;
    [Cardinality(9)]
    public int[] Icon = new int[9];
    public int FactionID;
    [Cardinality(2)]
    public float[] Pos = new float[2];
    public int ContinentID;
    public int Flags;
    public int AreaID;
    public string Name = string.Empty;
    public string Description = string.Empty;
    public int WorldStateID;
    public int WorldMapLink;
    public int PortLocID;
}
