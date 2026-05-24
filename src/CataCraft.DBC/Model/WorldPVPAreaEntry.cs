using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("world_PVP_Area.dbc")]
public sealed class WorldPVPAreaEntry
{
    [Index(false)]
    public uint ID;
    public int AreaID;
    public int NextTimeWorldstate;
    public int GameTimeWorldstate;
    public int BattlePopulateTime;
    public int MinLevel;
    public int MaxLevel;
}
