using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpamMessages.dbc")]
public sealed class SpamMessagesEntry
{
    [Index(true)]
    public uint ID;
    public string Text = string.Empty;
}
