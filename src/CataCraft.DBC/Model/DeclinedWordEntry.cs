using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DeclinedWord.dbc")]
public sealed class DeclinedWordEntry
{
    [Index(false)]
    public uint ID;
    public string Word = string.Empty;
}
