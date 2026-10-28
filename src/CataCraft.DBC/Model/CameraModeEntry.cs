using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CameraMode.dbc")]
public sealed class CameraModeEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Type;
    public int Flags;
    [Cardinality(3)]
    public float[] PositionOffset = new float[3];
    [Cardinality(3)]
    public float[] TargetOffset = new float[3];
    public float PositionSmoothing;
    public float RotationSmoothing;
    public float FieldOfView;
    public int LockedPositionOffsetBase;
    public int LockedPositionOffsetDirection;
    public int LockedTargetOffsetBase;
    public int LockedTargetOffsetDirection;
}
