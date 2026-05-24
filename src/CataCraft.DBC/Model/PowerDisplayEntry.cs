using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PowerDisplay.dbc")]
public sealed class PowerDisplayEntry
{
    [Index(false)]
    public uint ID;
    public int ActualType;
    public string GlobalStringBaseTag = string.Empty;
    public sbyte Red;
    public sbyte Green;
    public sbyte Blue;
    [Cardinality(1)]
    public sbyte[] Padding40011792006 = new sbyte[1];
}
