using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraOptions.dbc")]
public sealed class SpellAuraOptionsEntry
{
    [Index(false)]
    public uint ID;
    public int CumulativeAura;
    public int ProcChance;
    public int ProcCharges;
    public int ProcTypeMask;
}
