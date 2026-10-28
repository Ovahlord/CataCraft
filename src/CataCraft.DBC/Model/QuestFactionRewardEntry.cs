using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestFactionReward.dbc")]
public sealed class QuestFactionRewardEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(10)]
    public int[] Difficulty = new int[10];
}
