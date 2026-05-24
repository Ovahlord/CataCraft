using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellRange.dbc")]
public sealed class SpellRangeEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(2)]
    public float[] RangeMin = new float[2];
    [Cardinality(2)]
    public float[] RangeMax = new float[2];
    public int Flags;
    public string DisplayName = string.Empty;
    public string DisplayNameShort = string.Empty;
}
