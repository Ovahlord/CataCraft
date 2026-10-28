using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellCategory.dbc")]
public sealed class SpellCategoryEntry
{
    [Index(true)]
    public uint ID;
    public int Flags;
    public int UsesPerWeek;
    public string Name = string.Empty;
}
