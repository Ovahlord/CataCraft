using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraRestrictions.dbc")]
public sealed class SpellAuraRestrictionsEntry
{
    [Index(false)]
    public uint ID;
    public int SpellID;
    public int DifficultyID;
    public int CasterAuraState;
    public int TargetAuraState;
    public int ExcludeCasterAuraState;
    public int ExcludeTargetAuraState;
    public int CasterAuraSpell;
    public int TargetAuraSpell;
    public int ExcludeCasterAuraSpell;
    public int ExcludeTargetAuraSpell;
}
