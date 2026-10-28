using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DeclinedWordCases.dbc")]
public sealed class DeclinedWordCasesEntry
{
    [Index(true)]
    public uint ID;
    public int DeclinedWordID;
    public int CaseIndex;
    public string DeclinedWord = string.Empty;
}
