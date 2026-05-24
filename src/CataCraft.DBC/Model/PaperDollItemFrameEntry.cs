using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PaperDollItemFrame.dbc")]
public sealed class PaperDollItemFrameEntry
{
    [Index(false)]
    public uint ID;
    public string ItemButtonName = string.Empty;
    public string SlotIcon = string.Empty;
    public int SlotNumber;
}
