using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DeclinedWord.dbc")]
public sealed class DeclinedWordEntry
{
    [Index(true)]
    public uint ID;
    public string Word = string.Empty;
}
