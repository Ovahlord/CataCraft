using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PvpDifficulty.dbc")]
public sealed class PVPDifficultyEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int RangeIndex;
    public int MinLevel;
    public int MaxLevel;
    public int Difficulty;
}
