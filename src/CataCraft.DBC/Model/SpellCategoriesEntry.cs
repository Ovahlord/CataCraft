using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellCategories.dbc")]
public sealed class SpellCategoriesEntry
{
    [Index(false)]
    public uint ID;
    public int Category;
    public int DefenseType;
    public int DispelType;
    public int Mechanic;
    public int PreventionType;
    public int StartRecoveryCategory;
}
