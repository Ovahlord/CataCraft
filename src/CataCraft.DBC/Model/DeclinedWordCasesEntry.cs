using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DeclinedWordCases.dbc")]
public sealed class DeclinedWordCasesEntry
{
    [Index(false)]
    public uint ID;
    public int DeclinedWordID;
    public int CaseIndex;
    public string DeclinedWord = string.Empty;
}
