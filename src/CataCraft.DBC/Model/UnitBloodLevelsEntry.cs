using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("UnitBloodLevels.dbc")]
public sealed class UnitBloodLevelsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(3)]
    public int[] Violencelevel = new int[3];
}
