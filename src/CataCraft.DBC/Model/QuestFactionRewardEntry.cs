using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestFactionReward.dbc")]
public sealed class QuestFactionRewardEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(10)]
    public int[] Difficulty = new int[10];
}
