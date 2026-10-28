using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LanguageWords.dbc")]
public sealed class LanguageWordsEntry
{
    [Index(true)]
    public uint ID;
    public int LanguageID;
    public string Word = string.Empty;
}
