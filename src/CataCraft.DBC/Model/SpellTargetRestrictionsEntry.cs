using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellTargetRestrictions.dbc")]
public sealed class SpellTargetRestrictionsEntry
{
    [Index(false)]
    public uint ID;
    public float ConeAngle;
    public float Width;
    public int MaxTargetLevel;
    public int TargetCreatureType;
    public int Targets;
}
