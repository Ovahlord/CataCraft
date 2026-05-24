using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TalentTab.dbc")]
public sealed class TalentTabEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int SpellIconID;
    public int ClassMask;
    public int CategoryEnumID;
    public int OrderIndex;
    public string BackgroundFile = string.Empty;
    public string Description = string.Empty;
    public int RoleMask;
    [Cardinality(2)]
    public int[] MasterySpellID = new int[2];
}
