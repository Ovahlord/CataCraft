using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellRuneCost.dbc")]
public sealed class SpellRuneCostEntry
{
    [Index(true)]
    public uint ID;
    public int Blood;
    public int Unholy;
    public int Frost;
    public int RunicPower;
}
