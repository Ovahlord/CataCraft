using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundProviderPreferences.dbc")]
public sealed class SoundProviderPreferencesEntry
{
    [Index(false)]
    public uint ID;
    public string Description = string.Empty;
    public int Flags;
    public int EAXEnvironmentSelection;
    public float EAXDecayTime;
    public float EAX2EnvironmentSize;
    public float EAX2EnvironmentDiffusion;
    public int EAX2Room;
    public int EAX2RoomHF;
    public float EAX2DecayHFRatio;
    public int EAX2Reflections;
    public float EAX2ReflectionsDelay;
    public int EAX2Reverb;
    public float EAX2ReverbDelay;
    public float EAX2RoomRolloff;
    public float EAX2AirAbsorption;
    public int EAX3RoomLF;
    public float EAX3DecayLFRatio;
    public float EAX3EchoTime;
    public float EAX3EchoDepth;
    public float EAX3ModulationTime;
    public float EAX3ModulationDepth;
    public float EAX3HFReference;
    public float EAX3LFReference;
}
