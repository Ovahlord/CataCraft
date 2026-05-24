using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TaxiNodes.dbc")]
public sealed class TaxiNodesEntry
{
    [Index(false)]
    public uint ID;
    public int ContinentID;
    [Cardinality(3)]
    public float[] Pos = new float[3];
    public string Name = string.Empty;
    [Cardinality(2)]
    public int[] MountCreatureID = new int[2];
    public int Flags;
    [Cardinality(2)]
    public float[] MapOffset = new float[2];
}
