using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LFGDungeons.dbc")]
public sealed class LFGDungeonsEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int MinLevel;
    public int MaxLevel;
    public int TargetLevel;
    public int TargetLevelMin;
    public int TargetLevelMax;
    public int MapID;
    public int DifficultyID;
    public int Flags;
    public int TypeID;
    public int Faction;
    public string TextureFilename = string.Empty;
    public int ExpansionLevel;
    public int OrderIndex;
    public int GroupID;
    public string Description = string.Empty;
    public int RandomID;
    public int CountTank;
    public int CountHealer;
    public int CountDamage;
}
