using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FactionGroup.dbc")]
public sealed class FactionGroupEntry
{
    [Index(false)]
    public uint ID;
    public int MaskID;
    public string InternalName = string.Empty;
    public string Name = string.Empty;
}
