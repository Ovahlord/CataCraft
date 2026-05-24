using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Talent.dbc")]
public sealed class TalentEntry
{
    [Index(false)]
    public uint ID;
    public int TabID;
    public int TierID;
    public int ColumnIndex;
    [Cardinality(5)]
    public int[] SpellRank = new int[5];
    [Cardinality(3)]
    public int[] PrereqTalent = new int[3];
    [Cardinality(3)]
    public int[] PrereqRank = new int[3];
    public int Flags;
    public int RequiredSpellID;
    [Cardinality(2)]
    public int[] CategoryMask = new int[2];
}
