using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Spell.dbc")]
public sealed class SpellEntry
{
    [Index(false)]
    public uint ID;
    public int Attributes;
    public int AttributesEx;
    public int AttributesExB;
    public int AttributesExC;
    public int AttributesExD;
    public int AttributesExE;
    public int AttributesExF;
    public int AttributesExG;
    public int AttributesExH;
    public int AttributesExI;
    public int AttributesExJ;
    public int CastingTimeIndex;
    public int DurationIndex;
    public int PowerType;
    public int RangeIndex;
    public float Speed;
    [Cardinality(2)]
    public int[] SpellVisualID = new int[2];
    public int SpellIconID;
    public int ActiveIconID;
    public string Name = string.Empty;
    public string NameSubtext = string.Empty;
    public string Description = string.Empty;
    public string AuraDescription = string.Empty;
    public int SchoolMask;
    public int RuneCostID;
    public int SpellMissileID;
    public int DescriptionVariablesID;
    public int Difficulty;
    public float BonusCoefficient;
    public int ScalingID;
    public int AuraOptionsID;
    public int AuraRestrictionsID;
    public int CastingRequirementsID;
    public int CategoriesID;
    public int ClassOptionsID;
    public int CooldownsID;
    public int Unknown400;
    public int EquippedItemsID;
    public int InterruptsID;
    public int LevelsID;
    public int PowerDisplayID;
    public int ReagentsID;
    public int ShapeshiftID;
    public int TargetRestrictionsID;
    public int TotemsID;
    public int RequiredProjectID;
}
