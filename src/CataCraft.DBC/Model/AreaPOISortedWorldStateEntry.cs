using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaPOISortedWorldState.dbc")]
public sealed class AreaPOISortedWorldStateEntry
{
    [Index(false)]
    public uint ID;
    public int WorldStateID;
    public int CemeteryID;
}
