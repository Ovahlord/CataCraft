using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("EmotesText.dbc")]
public sealed class EmotesTextEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int EmoteID;
    [Cardinality(16)]
    public int[] EmoteText = new int[16];
}
