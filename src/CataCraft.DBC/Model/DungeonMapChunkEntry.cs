using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DungeonMapChunk.dbc")]
public sealed class DungeonMapChunkEntry
{
    [Index(true)]
    public uint ID;
    public int MapID;
    public int WMOGroupID;
    public int DungeonMapID;
    public float MinZ;
}
