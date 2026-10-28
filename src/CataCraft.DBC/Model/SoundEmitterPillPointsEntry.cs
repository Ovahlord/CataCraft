using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundEmitterPillPoints.dbc")]
public sealed class SoundEmitterPillPointsEntry
{
    [Index(true)]
    public uint ID;
    public int SoundEmittersID;
    [Cardinality(3)]
    public float[] Position = new float[3];
}
