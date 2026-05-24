using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpamMessages.dbc")]
public sealed class SpamMessagesEntry
{
    [Index(false)]
    public uint ID;
    public string Text = string.Empty;
}
