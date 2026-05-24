using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundEmitters.dbc")]
public sealed class SoundEmittersEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(3)]
    public float[] Position = new float[3];
    [Cardinality(3)]
    public float[] Direction = new float[3];
    public int SoundEntriesID;
    public int MapID;
    public string Name = string.Empty;
    public int EmitterType;
}
