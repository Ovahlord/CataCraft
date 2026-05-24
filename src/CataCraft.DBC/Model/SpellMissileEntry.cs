using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellMissile.dbc")]
public sealed class SpellMissileEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public float DefaultPitchMin;
    public float DefaultPitchMax;
    public float DefaultSpeedMin;
    public float DefaultSpeedMax;
    public float RandomizeFacingMin;
    public float RandomizeFacingMax;
    public float RandomizePitchMin;
    public float RandomizePitchMax;
    public float RandomizeSpeedMin;
    public float RandomizeSpeedMax;
    public float Gravity;
    public float MaxDuration;
    public float CollisionRadius;
}
