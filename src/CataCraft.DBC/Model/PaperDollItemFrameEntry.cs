using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PaperDollItemFrame.dbc")]
public sealed class PaperDollItemFrameEntry
{
    [Index(true)]
    public uint ID;
    public string ItemButtonName = string.Empty;
    public string SlotIcon = string.Empty;
    public int SlotNumber;
}
