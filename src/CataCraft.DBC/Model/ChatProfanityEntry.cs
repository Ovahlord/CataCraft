using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ChatProfanity.dbc")]
public sealed class ChatProfanityEntry
{
    [Index(true)]
    public uint ID;
    public string Text = string.Empty;
    public int Language;
}
