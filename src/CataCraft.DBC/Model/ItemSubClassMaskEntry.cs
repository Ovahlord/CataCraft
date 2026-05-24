using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemSubClassMask.dbc")]
public sealed class ItemSubClassMaskEntry
{
    [Index(false)]
    public uint ID;
    public int ClassID;
    public int Mask;
    public string Name = string.Empty;
}
