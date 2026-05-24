using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LanguageWords.dbc")]
public sealed class LanguageWordsEntry
{
    [Index(false)]
    public uint ID;
    public int LanguageID;
    public string Word = string.Empty;
}
