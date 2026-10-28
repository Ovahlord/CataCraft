using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Emotes.dbc")]
public sealed class EmotesEntry
{
    [Index(true)]
    public uint ID;
    public string EmoteSlashCommand = string.Empty;
    public int AnimID;
    public int EmoteFlags;
    public int EmoteSpecProc;
    public int EmoteSpecProcParam;
    public int EventSoundID;
    public int SpellVisualKitID;
}
