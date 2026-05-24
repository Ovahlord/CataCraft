using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GuildColorBorder.dbc")]
public sealed class GuildColorBorderEntry
{
    [Index(false)]
    public uint ColorID;
    public sbyte Red;
    public sbyte Green;
    public sbyte Blue;
    [Cardinality(1)]
    public sbyte[] Padding60118179004 = new sbyte[1];
}
