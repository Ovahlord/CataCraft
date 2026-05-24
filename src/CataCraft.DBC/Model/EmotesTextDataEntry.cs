using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EmotesTextData.dbc")]
public sealed class EmotesTextDataEntry
{
    [Index(false)]
    public uint ID;
    public string Text = string.Empty;
}
