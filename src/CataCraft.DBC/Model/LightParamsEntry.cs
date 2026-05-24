using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LightParams.dbc")]
public sealed class LightParamsEntry
{
    [Index(false)]
    public uint ID;
    public int HighlightSky;
    public int LightSkyboxID;
    public int CloudTypeID;
    public float Glow;
    public float WaterShallowAlpha;
    public float WaterDeepAlpha;
    public float OceanShallowAlpha;
    public float OceanDeepAlpha;
    public int Flags;
}
