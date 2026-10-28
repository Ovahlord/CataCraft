using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellReagents.dbc")]
public sealed class SpellReagentsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(8)]
    public int[] Reagent = new int[8];
    [Cardinality(8)]
    public int[] ReagentCount = new int[8];
}
