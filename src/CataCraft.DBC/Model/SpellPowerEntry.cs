using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellPower.dbc")]
public sealed class SpellPowerEntry
{
    [Index(true)]
    public uint ID;
    public int ManaCost;
    public int ManaCostPerLevel;
    public int PowerCost;
    public int ManaPerSecond;
    public int PowerDisplayID;
    public int AltPowerBarID;
    public float PowerCostPct;
}
