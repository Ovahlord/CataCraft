using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TaxiPathNode.dbc")]
public sealed class TaxiPathNodeEntry
{
    [Index(true)]
    public uint ID;
    public int PathID;
    public int NodeIndex;
    public int ContinentID;
    [Cardinality(3)]
    public float[] Loc = new float[3];
    public int Flags;
    public int Delay;
    public int ArrivalEventID;
    public int DepartureEventID;
}
