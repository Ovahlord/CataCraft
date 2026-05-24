using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundEntries.dbc")]
public sealed class SoundEntriesEntry
{
    [Index(false)]
    public uint ID;
    public int SoundType;
    public string Name = string.Empty;
    [Cardinality(10)]
    public string[] File = new string[10];
    [Cardinality(10)]
    public int[] Freq = new int[10];
    public string DirectoryBase = string.Empty;
    public float VolumeFloat;
    public int Flags;
    public float MinDistance;
    public float DistanceCutoff;
    public int EAXDef;
    public int SoundEntriesAdvancedID;
    public float Volumevariationplus;
    public float Volumevariationminus;
    public float Pitchvariationplus;
    public float Pitchvariationminus;
    public float PitchAdjust;
}
