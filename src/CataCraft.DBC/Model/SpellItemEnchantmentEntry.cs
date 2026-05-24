using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellItemEnchantment.dbc")]
public sealed class SpellItemEnchantmentEntry
{
    [Index(false)]
    public uint ID;
    public int Charges;
    [Cardinality(3)]
    public int[] Effect = new int[3];
    [Cardinality(3)]
    public int[] EffectPointsMin = new int[3];
    [Cardinality(3)]
    public int[] EffectPointsMax = new int[3];
    [Cardinality(3)]
    public int[] EffectArg = new int[3];
    public string Name = string.Empty;
    public int ItemVisual;
    public int Flags;
    public int SrcItemID;
    public int ConditionID;
    public int RequiredSkillID;
    public int RequiredSkillRank;
    public int MinLevel;
    public int ItemLevel;
}
