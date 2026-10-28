using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundAmbienceFlavor.dbc")]
public sealed class SoundAmbienceFlavorEntry
{
    [Index(true)]
    public uint ID;
    public int SoundAmbienceID;
    public int SoundEntriesIDDay;
    public int SoundEntriesIDNight;
}
