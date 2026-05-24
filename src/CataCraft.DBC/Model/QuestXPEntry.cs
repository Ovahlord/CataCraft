using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestXP.dbc")]
public sealed class QuestXPEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(10)]
    public int[] Difficulty = new int[10];
}
