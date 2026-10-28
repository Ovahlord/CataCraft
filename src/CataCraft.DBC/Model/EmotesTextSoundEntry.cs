using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EmotesTextSound.dbc")]
public sealed class EmotesTextSoundEntry
{
    [Index(true)]
    public uint ID;
    public int EmotesTextID;
    public int RaceID;
    public int SexID;
    public int SoundID;
}
