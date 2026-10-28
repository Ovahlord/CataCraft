using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PvpDifficulty.dbc")]
public sealed class PVPDifficultyEntry
{
    [Index(true)]
    public uint ID;
    public int MapID;
    public int RangeIndex;
    public int MinLevel;
    public int MaxLevel;
    public int Difficulty;
}
