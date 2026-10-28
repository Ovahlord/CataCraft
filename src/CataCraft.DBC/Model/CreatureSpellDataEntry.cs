using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureSpellData.dbc")]
public sealed class CreatureSpellDataEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(4)]
    public int[] Spells = new int[4];
    [Cardinality(4)]
    public int[] Availability = new int[4];
}
