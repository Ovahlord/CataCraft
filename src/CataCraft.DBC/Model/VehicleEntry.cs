using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Vehicle.dbc")]
public sealed class VehicleEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public float TurnSpeed;
    public float PitchSpeed;
    public float PitchMin;
    public float PitchMax;
    [Cardinality(8)]
    public int[] SeatID = new int[8];
    public float MouseLookOffsetPitch;
    public float CameraFadeDistScalarMin;
    public float CameraFadeDistScalarMax;
    public float CameraPitchOffset;
    public float FacingLimitRight;
    public float FacingLimitLeft;
    public float MsslTrgtTurnLingering;
    public float MsslTrgtPitchLingering;
    public float MsslTrgtMouseLingering;
    public float MsslTrgtEndOpacity;
    public float MsslTrgtArcSpeed;
    public float MsslTrgtArcRepeat;
    public float MsslTrgtArcWidth;
    [Cardinality(2)]
    public float[] MsslTrgtImpactRadius = new float[2];
    public string MsslTrgtArcTexture = string.Empty;
    public string MsslTrgtImpactTexture = string.Empty;
    [Cardinality(2)]
    public string[] MsslTrgtImpactModel = new string[2];
    public float CameraYawOffset;
    public int UiLocomotionType;
    public float MsslTrgtImpactTexRadius;
    public int VehicleUIIndicatorID;
    [Cardinality(3)]
    public int[] PowerDisplayID = new int[3];
}
