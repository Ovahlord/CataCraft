using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraVisibility.dbc")]
public sealed class SpellAuraVisibilityEntry
{
    [Index(true)]
    public uint ID;
    public int SpellID;
    public int Type;
    public int Flags;
}
