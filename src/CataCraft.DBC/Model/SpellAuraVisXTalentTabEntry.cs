using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraVisXTalentTab.dbc")]
public sealed class SpellAuraVisXTalentTabEntry
{
    [Index(true)]
    public uint ID;
    public int SpellAuraVisibilityID;
    public int TalentTabID;
}
