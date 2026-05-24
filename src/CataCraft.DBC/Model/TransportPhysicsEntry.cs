using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TransportPhysics.dbc")]
public sealed class TransportPhysicsEntry
{
    [Index(false)]
    public uint ID;
    public float WaveAmp;
    public float WaveTimeScale;
    public float RollAmp;
    public float RollTimeScale;
    public float PitchAmp;
    public float PitchTimeScale;
    public float MaxBank;
    public float MaxBankTurnSpeed;
    public float SpeedDampThresh;
    public float SpeedDamp;
}
