using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EmotesTextData.dbc")]
public sealed class EmotesTextDataEntry
{
    [Index(true)]
    public uint ID;
    public string Text = string.Empty;
}
