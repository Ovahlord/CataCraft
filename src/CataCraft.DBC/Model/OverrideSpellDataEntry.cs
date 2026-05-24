using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("OverrideSpellData.dbc")]
public sealed class OverrideSpellDataEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(10)]
    public int[] Spells = new int[10];
    public int Flags;
    public string PlayerActionbar = string.Empty;
}
