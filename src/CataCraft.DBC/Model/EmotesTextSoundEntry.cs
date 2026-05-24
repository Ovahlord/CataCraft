using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EmotesTextSound.dbc")]
public sealed class EmotesTextSoundEntry
{
    [Index(false)]
    public uint ID;
    public int EmotesTextID;
    public int RaceID;
    public int SexID;
    public int SoundID;
}
