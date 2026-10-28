using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DungeonMap.dbc")]
public sealed class DungeonMapEntry
{
    [Index(true)]
    public uint ID;
    public int MapID;
    public int FloorIndex;
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public int ParentWorldMapID;
}
