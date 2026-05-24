using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellTotems.dbc")]
public sealed class SpellTotemsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(2)]
    public int[] RequiredTotemCategoryID = new int[2];
    [Cardinality(2)]
    public int[] Totem = new int[2];
}
