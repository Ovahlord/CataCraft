using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ChatProfanity.dbc")]
public sealed class ChatProfanityEntry
{
    [Index(false)]
    public uint ID;
    public string Text = string.Empty;
    public int Language;
}
