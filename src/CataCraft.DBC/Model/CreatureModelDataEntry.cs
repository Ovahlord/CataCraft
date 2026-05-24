using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureModelData.dbc")]
public sealed class CreatureModelDataEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public string ModelName = string.Empty;
    public int SizeClass;
    public float ModelScale;
    public int BloodID;
    public int FootprintTextureID;
    public float FootprintTextureLength;
    public float FootprintTextureWidth;
    public float FootprintParticleScale;
    public int FoleyMaterialID;
    public int FootstepShakeSize;
    public int DeathThudShakeSize;
    public int SoundID;
    public float CollisionWidth;
    public float CollisionHeight;
    public float MountHeight;
    [Cardinality(3)]
    public float[] GeoBoxMin = new float[3];
    [Cardinality(3)]
    public float[] GeoBoxMax = new float[3];
    public float WorldEffectScale;
    public float AttachedEffectScale;
    public float MissileCollisionRadius;
    public float MissileCollisionPush;
    public float MissileCollisionRaise;
    public float OverrideLootEffectScale;
    public float OverrideNameScale;
    public float TamedPetBaseScale;
}
