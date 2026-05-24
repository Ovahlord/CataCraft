using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundEntriesFallbacks.dbc")]
public sealed class SoundEntriesFallbacksEntry
{
    [Index(false)]
    public uint ID;
    public int SoundEntriesID;
    public int FallbackSoundEntriesID;
}
