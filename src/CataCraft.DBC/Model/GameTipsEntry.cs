using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GameTips.dbc")]
public sealed class GameTipsEntry
{
    [Index(false)]
    public uint ID;
    public string Text = string.Empty;
    public int MinLevel;
    public int MaxLevel;
}
