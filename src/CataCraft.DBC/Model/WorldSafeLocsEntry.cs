using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldSafeLocs.dbc")]
public sealed class WorldSafeLocsEntry
{
    [Index(false)]
    public uint ID;
    public int Continent;
    [Cardinality(3)]
    public float[] Loc = new float[3];
    public string AreaName = string.Empty;
}
