using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ResearchProject.dbc")]
public sealed class ResearchProjectEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public string Description = string.Empty;
    public int Rarity;
    public int ResearchBranchID;
    public int SpellID;
    public int NumSockets;
    public string Texture = string.Empty;
    public int RequiredWeight;
}
