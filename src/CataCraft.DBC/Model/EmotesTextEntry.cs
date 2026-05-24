using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EmotesText.dbc")]
public sealed class EmotesTextEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int EmoteID;
    [Cardinality(16)]
    public int[] EmoteText = new int[16];
}
