using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GroundEffectTexture.dbc")]
public sealed class GroundEffectTextureEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(4)]
    public int[] DoodadID = new int[4];
    [Cardinality(4)]
    public int[] DoodadWeight = new int[4];
    public int Density;
    public int Sound;
}
