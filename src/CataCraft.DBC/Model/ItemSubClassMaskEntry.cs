using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemSubClassMask.dbc")]
public sealed class ItemSubClassMaskEntry
{
    [Index(true)]
    public uint ID;
    public int ClassID;
    public int Mask;
    public string Name = string.Empty;
}
