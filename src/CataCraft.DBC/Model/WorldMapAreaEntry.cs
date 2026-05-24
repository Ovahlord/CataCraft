using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldMapArea.dbc")]
public sealed class WorldMapAreaEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int AreaID;
    public string AreaName = string.Empty;
    public float LocLeft;
    public float LocRight;
    public float LocTop;
    public float LocBottom;
    public int DisplayMapID;
    public int DefaultDungeonFloor;
    public int ParentWorldMapID;
    public int Flags;
    public int LevelRangeMin;
    public int LevelRangeMax;
}
