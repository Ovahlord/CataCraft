using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GroundEffectTexture.dbc")]
public sealed class GroundEffectTextureEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(4)]
    public int[] DoodadID = new int[4];
    [Cardinality(4)]
    public int[] DoodadWeight = new int[4];
    public int Density;
    public int Sound;
}
