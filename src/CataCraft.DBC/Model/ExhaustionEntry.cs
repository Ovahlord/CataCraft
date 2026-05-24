using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Exhaustion.dbc")]
public sealed class ExhaustionEntry
{
    [Index(false)]
    public uint ID;
    public int Xp;
    public float Factor;
    public float OutdoorHours;
    public float InnHours;
    public string Name = string.Empty;
    public float Threshold;
}
