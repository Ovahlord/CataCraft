using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Achievement_Category.dbc")]
public sealed class AchievementCategoryEntry
{
    [Index(true)]
    public uint ID;
    public int Parent;
    public string Name = string.Empty;
    public int UiOrder;
}
