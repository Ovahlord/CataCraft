using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellTotems.dbc")]
public sealed class SpellTotemsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(2)]
    public int[] RequiredTotemCategoryID = new int[2];
    [Cardinality(2)]
    public int[] Totem = new int[2];
}
