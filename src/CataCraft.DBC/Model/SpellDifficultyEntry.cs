using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellDifficulty.dbc")]
public sealed class SpellDifficultyEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(4)]
    public int[] DifficultySpellID = new int[4];
}
