using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellEffect.dbc")]
public sealed class SpellEffectEntry
{
    [Index(false)]
    public uint ID;
    public int Effect;
    public float EffectAmplitude;
    public int EffectAura;
    public int EffectAuraPeriod;
    public int EffectBasePoints;
    public float EffectBonusCoefficient;
    public float EffectChainAmplitude;
    public int EffectChainTargets;
    public int EffectDieSides;
    public int EffectItemType;
    public int EffectMechanic;
    [Cardinality(2)]
    public int[] EffectMiscValue = new int[2];
    public float EffectPointsPerResource;
    [Cardinality(2)]
    public int[] EffectRadiusIndex = new int[2];
    public float EffectRealPointsPerLevel;
    [Cardinality(3)]
    public int[] EffectSpellClassMask = new int[3];
    public int EffectTriggerSpell;
    [Cardinality(2)]
    public int[] ImplicitTarget = new int[2];
    public int SpellID;
    public int EffectIndex;
    public int EffectAttributes;
}
