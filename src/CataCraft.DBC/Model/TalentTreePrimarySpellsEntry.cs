using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TalentTreePrimarySpells.dbc")]
public sealed class TalentTreePrimarySpellsEntry
{
    [Index(true)]
    public uint ID;
    public int TalentTabID;
    public int SpellID;
    public int Flags;
}
