using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("UnitBlood.dbc")]
public sealed class UnitBloodEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(2)]
    public int[] CombatBloodSpurtFront = new int[2];
    [Cardinality(2)]
    public int[] CombatBloodSpurtBack = new int[2];
    [Cardinality(5)]
    public string[] GroundBlood = new string[5];
}
