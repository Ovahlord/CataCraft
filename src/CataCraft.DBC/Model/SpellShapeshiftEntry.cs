using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellShapeshift.dbc")]
public sealed class SpellShapeshiftEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(2)]
    public int[] ShapeshiftExclude = new int[2];
    [Cardinality(2)]
    public int[] ShapeshiftMask = new int[2];
    public int StanceBarOrder;
}
