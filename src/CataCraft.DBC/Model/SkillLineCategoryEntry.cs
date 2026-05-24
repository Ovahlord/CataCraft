using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillLineCategory.dbc")]
public sealed class SkillLineCategoryEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int SortIndex;
}
