using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Weather.dbc")]
public sealed class WeatherEntry
{
    [Index(false)]
    public uint ID;
    public int AmbienceID;
    public int EffectType;
    public float TransitionSkyBox;
    [Cardinality(3)]
    public float[] EffectColor = new float[3];
    public string EffectTexture = string.Empty;
}
