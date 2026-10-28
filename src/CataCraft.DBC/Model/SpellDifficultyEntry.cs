using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellDifficulty.dbc")]
public sealed class SpellDifficultyEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(4)]
    public int[] DifficultySpellID = new int[4];
}
