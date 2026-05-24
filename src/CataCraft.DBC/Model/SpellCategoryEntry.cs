using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellCategory.dbc")]
public sealed class SpellCategoryEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public int UsesPerWeek;
    public string Name = string.Empty;
}
