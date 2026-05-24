using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemDisplayInfo.dbc")]
public sealed class ItemDisplayInfoEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(2)]
    public string[] ModelName = new string[2];
    [Cardinality(2)]
    public string[] ModelTexture = new string[2];
    [Cardinality(2)]
    public string[] InventoryIcon = new string[2];
    [Cardinality(3)]
    public int[] GeosetGroup = new int[3];
    public int Flags;
    public int SpellVisualID;
    public int GroupSoundIndex;
    [Cardinality(2)]
    public int[] HelmetGeosetVisID = new int[2];
    [Cardinality(8)]
    public string[] Texture = new string[8];
    public int ItemVisual;
    public int ParticleColorID;
}
