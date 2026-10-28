using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellClassOptions.dbc")]
public sealed class SpellClassOptionsEntry
{
    [Index(true)]
    public uint ID;
    public int ModalNextSpell;
    [Cardinality(3)]
    public int[] SpellClassMask = new int[3];
    public int SpellClassSet;
    public string Description = string.Empty;
}
