using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillLineAbilitySortedSpell.dbc")]
public sealed class SkillLineAbilitySortedSpellEntry
{
    [Index(false)]
    public uint ID;
    public int Spell;
}
