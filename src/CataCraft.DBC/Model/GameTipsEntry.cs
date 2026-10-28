using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GameTips.dbc")]
public sealed class GameTipsEntry
{
    [Index(true)]
    public uint ID;
    public string Text = string.Empty;
    public int MinLevel;
    public int MaxLevel;
}
