using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ResearchSite.dbc")]
public sealed class ResearchSiteEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int QuestPOIBlobID;
    public string Name = string.Empty;
    public int AreaPOIIconEnum;
}
