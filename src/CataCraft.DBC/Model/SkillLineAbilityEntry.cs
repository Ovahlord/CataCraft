using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillLineAbility.dbc")]
public sealed class SkillLineAbilityEntry
{
    [Index(false)]
    public uint ID;
    public int SkillLine;
    public int Spell;
    public int RaceMask;
    public int ClassMask;
    public int ExcludeRace;
    public int ExcludeClass;
    public int MinSkillLineRank;
    public int SupercededBySpell;
    public int AcquireMethod;
    public int TrivialSkillLineRankHigh;
    public int TrivialSkillLineRankLow;
    public int NumSkillUps;
    public int UniqueBit;
}
