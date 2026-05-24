using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("UnitPowerBar.dbc")]
public sealed class UnitPowerBarEntry
{
    [Index(false)]
    public uint ID;
    public int MinPower;
    public int MaxPower;
    public int StartPower;
    public int CenterPower;
    public float RegenerationPeace;
    public float RegenerationCombat;
    public int BarType;
    [Cardinality(6)]
    public int[] FileDataID = new int[6];
    [Cardinality(6)]
    public int[] Color = new int[6];
    public int Flags;
    public string Name = string.Empty;
    public string Cost = string.Empty;
    public string OutOfError = string.Empty;
    public string ToolTip = string.Empty;
    public float StartInset;
    public float EndInset;
}
