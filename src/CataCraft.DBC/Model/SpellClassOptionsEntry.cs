using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellClassOptions.dbc")]
public sealed class SpellClassOptionsEntry
{
    [Index(false)]
    public uint ID;
    public int ModalNextSpell;
    [Cardinality(3)]
    public int[] SpellClassMask = new int[3];
    public int SpellClassSet;
    public string Description = string.Empty;
}
