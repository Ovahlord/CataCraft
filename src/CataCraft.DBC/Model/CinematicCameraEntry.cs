using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CinematicCamera.dbc")]
public sealed class CinematicCameraEntry
{
    [Index(true)]
    public uint ID;
    public string Model = string.Empty;
    public int SoundID;
    [Cardinality(3)]
    public float[] Origin = new float[3];
    public float OriginFacing;
}
