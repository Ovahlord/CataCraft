using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillLineAbilitySortedSpell.dbc")]
public sealed class SkillLineAbilitySortedSpellEntry
{
    [Index(true)]
    public uint ID;
    public int Spell;
}
