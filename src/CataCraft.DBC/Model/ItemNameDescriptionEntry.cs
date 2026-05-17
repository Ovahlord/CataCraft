using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemNameDescription.dbc")]
public sealed class ItemNameDescriptionEntry
{
    [Index(true)]
    public uint ID;
    public string Description = string.Empty;
    public int Color;
}
