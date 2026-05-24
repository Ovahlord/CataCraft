using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DungeonMapChunk.dbc")]
public sealed class DungeonMapChunkEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int WMOGroupID;
    public int DungeonMapID;
    public float MinZ;
}
