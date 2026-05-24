using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureSpellData.dbc")]
public sealed class CreatureSpellDataEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(4)]
    public int[] Spells = new int[4];
    [Cardinality(4)]
    public int[] Availability = new int[4];
}
