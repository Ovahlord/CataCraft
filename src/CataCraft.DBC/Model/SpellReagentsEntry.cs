using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellReagents.dbc")]
public sealed class SpellReagentsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(8)]
    public int[] Reagent = new int[8];
    [Cardinality(8)]
    public int[] ReagentCount = new int[8];
}
