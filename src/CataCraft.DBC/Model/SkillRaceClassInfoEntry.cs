using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillRaceClassInfo.dbc")]
public sealed class SkillRaceClassInfoEntry
{
    [Index(false)]
    public uint ID;
    public int SkillID;
    public int RaceMask;
    public int ClassMask;
    public int Flags;
    public int Availability;
    public int MinLevel;
    public int SkillTierID;
    public int SkillCostIndex;
}
