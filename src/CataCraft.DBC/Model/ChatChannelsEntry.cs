using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ChatChannels.dbc")]
public sealed class ChatChannelsEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public int FactionGroup;
    public string Name = string.Empty;
    public string Shortcut = string.Empty;
}
