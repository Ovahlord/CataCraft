using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ServerMessages.dbc")]
public sealed class ServerMessagesEntry
{
    [Index(true)]
    public uint ID;
    public string Text = string.Empty;
}
