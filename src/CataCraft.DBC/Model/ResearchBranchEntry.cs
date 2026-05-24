using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ResearchBranch.dbc")]
public sealed class ResearchBranchEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int ResearchFieldID;
    public int CurrencyID;
    public string Texture = string.Empty;
    public int ItemID;
}
