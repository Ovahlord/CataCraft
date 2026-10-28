using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaAssignment.dbc")]
public sealed class AreaAssignmentEntry
{
    [Index(true)]
    public uint ID;
    public int MapID;
    public int AreaID;
    public int ChunkX;
    public int ChunkY;
}
