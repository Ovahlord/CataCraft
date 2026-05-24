using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaAssignment.dbc")]
public sealed class AreaAssignmentEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int AreaID;
    public int ChunkX;
    public int ChunkY;
}
