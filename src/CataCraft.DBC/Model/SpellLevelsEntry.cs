using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellLevels.dbc")]
public sealed class SpellLevelsEntry
{
    [Index(true)]
    public uint ID;
    public int BaseLevel;
    public int MaxLevel;
    public int SpellLevel;
}
