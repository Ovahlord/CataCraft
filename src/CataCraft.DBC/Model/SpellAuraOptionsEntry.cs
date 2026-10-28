using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraOptions.dbc")]
public sealed class SpellAuraOptionsEntry
{
    [Index(true)]
    public uint ID;
    public int CumulativeAura;
    public int ProcChance;
    public int ProcCharges;
    public int ProcTypeMask;
}
