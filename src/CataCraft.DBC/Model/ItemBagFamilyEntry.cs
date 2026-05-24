using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemBagFamily.dbc")]
public sealed class ItemBagFamilyEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
