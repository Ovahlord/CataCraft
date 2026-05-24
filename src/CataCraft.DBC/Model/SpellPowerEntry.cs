using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellPower.dbc")]
public sealed class SpellPowerEntry
{
    [Index(false)]
    public uint ID;
    public int ManaCost;
    public int ManaCostPerLevel;
    public int PowerCost;
    public int ManaPerSecond;
    public int PowerDisplayID;
    public int AltPowerBarID;
    public float PowerCostPct;
}
