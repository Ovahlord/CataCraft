using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaPOISortedWorldState.dbc")]
public sealed class AreaPOISortedWorldStateEntry
{
    [Index(true)]
    public uint ID;
    public int WorldStateID;
    public int CemeteryID;
}
