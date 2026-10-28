using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillLineCategory.dbc")]
public sealed class SkillLineCategoryEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int SortIndex;
}
