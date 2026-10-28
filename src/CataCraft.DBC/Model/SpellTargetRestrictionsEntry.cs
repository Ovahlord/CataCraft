using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellTargetRestrictions.dbc")]
public sealed class SpellTargetRestrictionsEntry
{
    [Index(true)]
    public uint ID;
    public float ConeAngle;
    public float Width;
    public int MaxTargetLevel;
    public int TargetCreatureType;
    public int Targets;
}
