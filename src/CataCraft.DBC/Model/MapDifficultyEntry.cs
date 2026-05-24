using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MapDifficulty.dbc")]
public sealed class MapDifficultyEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int Difficulty;
    public string Message = string.Empty;
    public int RaidDuration;
    public int MaxPlayers;
    public string Difficultystring = string.Empty;
}
