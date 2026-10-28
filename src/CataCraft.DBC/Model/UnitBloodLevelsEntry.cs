using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("UnitBloodLevels.dbc")]
public sealed class UnitBloodLevelsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(3)]
    public int[] Violencelevel = new int[3];
}
