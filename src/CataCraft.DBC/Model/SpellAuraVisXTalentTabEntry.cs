using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraVisXTalentTab.dbc")]
public sealed class SpellAuraVisXTalentTabEntry
{
    [Index(false)]
    public uint ID;
    public int SpellAuraVisibilityID;
    public int TalentTabID;
}
