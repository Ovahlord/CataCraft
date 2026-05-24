using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LiquidType.dbc")]
public sealed class LiquidTypeEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
    public int SoundBank;
    public int SoundID;
    public int SpellID;
    public float MaxDarkenDepth;
    public float FogDarkenIntensity;
    public float AmbDarkenIntensity;
    public float DirDarkenIntensity;
    public int LightID;
    public float ParticleScale;
    public int ParticleMovement;
    public int ParticleTexSlots;
    public int MaterialID;
    [Cardinality(6)]
    public string[] Texture = new string[6];
    [Cardinality(2)]
    public int[] Color = new int[2];
    [Cardinality(18)]
    public float[] Float = new float[18];
    [Cardinality(4)]
    public int[] Int = new int[4];
}
