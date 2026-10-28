using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestXP.dbc")]
public sealed class QuestXPEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(10)]
    public int[] Difficulty = new int[10];
}
