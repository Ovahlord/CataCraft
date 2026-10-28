using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LFGDungeonExpansion.dbc")]
public sealed class LFGDungeonExpansionEntry
{
    [Index(true)]
    public uint ID;
    public int LfgID;
    public int ExpansionLevel;
    public int RandomID;
    public int HardLevelMin;
    public int HardLevelMax;
    public int TargetLevelMin;
    public int TargetLevelMax;
}
