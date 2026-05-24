using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DungeonMap.dbc")]
public sealed class DungeonMapEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int FloorIndex;
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public int ParentWorldMapID;
}
