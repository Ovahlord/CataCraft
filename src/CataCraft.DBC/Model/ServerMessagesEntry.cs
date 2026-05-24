using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ServerMessages.dbc")]
public sealed class ServerMessagesEntry
{
    [Index(false)]
    public uint ID;
    public string Text = string.Empty;
}
