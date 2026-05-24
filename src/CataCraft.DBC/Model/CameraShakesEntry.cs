using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CameraShakes.dbc")]
public sealed class CameraShakesEntry
{
    [Index(false)]
    public uint ID;
    public int ShakeType;
    public int Direction;
    public float Amplitude;
    public float Frequency;
    public float Duration;
    public float Phase;
    public float Coefficient;
    public int Flags;
}
