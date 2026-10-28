using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraRestrictions.dbc")]
public sealed class SpellAuraRestrictionsEntry
{
    [Index(true)]
    public uint ID;
    public int CasterAuraState;
    public int TargetAuraState;
    public int ExcludeCasterAuraState;
    public int ExcludeTargetAuraState;
    public int CasterAuraSpell;
    public int TargetAuraSpell;
    public int ExcludeCasterAuraSpell;
    public int ExcludeTargetAuraSpell;
}
