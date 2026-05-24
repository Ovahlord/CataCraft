using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GameObjectDisplayInfo.dbc")]
public sealed class GameObjectDisplayInfoEntry
{
    [Index(false)]
    public uint ID;
    public string ModelName = string.Empty;
    [Cardinality(10)]
    public int[] Sound = new int[10];
    [Cardinality(3)]
    public float[] GeoBoxMin = new float[3];
    [Cardinality(3)]
    public float[] GeoBoxMax = new float[3];
    public int ObjectEffectPackageID;
    public float OverrideLootEffectScale;
    public float OverrideNameScale;
}
