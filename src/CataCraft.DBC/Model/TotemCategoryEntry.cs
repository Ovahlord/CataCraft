using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TotemCategory.dbc")]
public sealed class TotemCategoryEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int TotemCategoryType;
    public int TotemCategoryMask;
}
