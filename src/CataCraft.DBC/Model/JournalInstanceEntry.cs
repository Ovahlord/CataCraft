using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("JournalInstance.dbc")]
public sealed class JournalInstanceEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int AreaID;
    public int ButtonFileDataID;
    public int BackgroundFileDataID;
    public int LoreFileDataID;
    public int Unknown420;
    public string Name = string.Empty;
    public string Description = string.Empty;
}
