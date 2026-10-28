using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ResearchSite.dbc")]
public sealed class ResearchSiteEntry
{
    [Index(true)]
    public uint ID;
    public int MapID;
    public int QuestPOIBlobID;
    public string Name = string.Empty;
    public int AreaPOIIconEnum;
}
