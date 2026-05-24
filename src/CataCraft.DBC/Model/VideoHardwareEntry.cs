using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("VideoHardware.dbc")]
public sealed class VideoHardwareEntry
{
    [Index(false)]
    public uint ID;
    public int VendorID;
    public int DeviceID;
    public int FarclipIdx;
    public int TerrainLODDistIdx;
    public int TerrainShadowLOD;
    public int DetailDoodadDensityIdx;
    public int DetailDoodadAlpha;
    public int AnimatingDoodadIdx;
    public int Trilinear;
    public int NumLights;
    public int Specularity;
    public int WaterLODIdx;
    public int ParticleDensityIdx;
    public int UnitDrawDistIdx;
    public int SmallCullDistIdx;
    public int ResolutionIdx;
    public int BaseMipLevel;
    public string OglOverrides = string.Empty;
    public string D3dOverrides = string.Empty;
    public int FixLag;
    public int Multisample;
    public int Atlasdisable;
}
