using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TotemCategory.dbc")]
public sealed class TotemCategoryEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int TotemCategoryType;
    public int TotemCategoryMask;
}
