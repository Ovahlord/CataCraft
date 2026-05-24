using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellChainEffects.dbc")]
public sealed class SpellChainEffectsEntry
{
    [Index(false)]
    public uint ID;
    public float AvgSegLen;
    public float Width;
    public float NoiseScale;
    public float TexCoordScale;
    public int SegDuration;
    public int SegDelay;
    public string Texture = string.Empty;
    public int Flags;
    public int JointCount;
    public float JointOffsetRadius;
    public int JointsPerMinorJoint;
    public int MinorJointsPerMajorJoint;
    public float MinorJointScale;
    public float MajorJointScale;
    public float JointMoveSpeed;
    public float JointSmoothness;
    public float MinDurationBetweenJointJumps;
    public float MaxDurationBetweenJointJumps;
    public float WaveHeight;
    public float WaveFreq;
    public float WaveSpeed;
    public float MinWaveAngle;
    public float MaxWaveAngle;
    public float MinWaveSpin;
    public float MaxWaveSpin;
    public float ArcHeight;
    public float MinArcAngle;
    public float MaxArcAngle;
    public float MinArcSpin;
    public float MaxArcSpin;
    public float DelayBetweenEffects;
    public float MinFlickerOnDuration;
    public float MaxFlickerOnDuration;
    public float MinFlickerOffDuration;
    public float MaxFlickerOffDuration;
    public float PulseSpeed;
    public float PulseOnLength;
    public float PulseFadeLength;
    public sbyte Alpha;
    public sbyte Red;
    public sbyte Green;
    public sbyte Blue;
    public sbyte BlendMode;
    [Cardinality(3)]
    public sbyte[] Padding40011792044 = new sbyte[3];
    public string Combo = string.Empty;
    public int RenderLayer;
    public float TextureLength;
    public float WavePhase;
}
