using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DurabilityCosts.dbc")]
public sealed class DurabilityCostsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(21)]
    public int[] WeaponSubClassCost = new int[21];
    [Cardinality(8)]
    public int[] ArmorSubClassCost = new int[8];
}
