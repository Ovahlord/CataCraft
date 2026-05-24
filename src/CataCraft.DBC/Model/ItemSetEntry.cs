using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemSet.dbc")]
public sealed class ItemSetEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    [Cardinality(17)]
    public int[] ItemID = new int[17];
    [Cardinality(8)]
    public int[] SetSpellID = new int[8];
    [Cardinality(8)]
    public int[] SetThreshold = new int[8];
    public int RequiredSkill;
    public int RequiredSkillRank;
}
