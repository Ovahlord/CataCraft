using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureDisplayInfo.dbc")]
public sealed class CreatureDisplayInfoEntry
{
    [Index(false)]
    public uint ID;
    public int ModelID;
    public int SoundID;
    public int ExtendedDisplayInfoID;
    public float CreatureModelScale;
    public int CreatureModelAlpha;
    [Cardinality(3)]
    public string[] TextureVariation = new string[3];
    public string PortraitTextureName = string.Empty;
    public int SizeClass;
    public int BloodID;
    public int NPCSoundID;
    public int ParticleColorID;
    public int CreatureGeosetData;
    public int ObjectEffectPackageID;
    public int AnimReplacementSetID;
}
