using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GuildColorEmblem.dbc")]
public sealed class GuildColorEmblemEntry
{
    [Index(true)]
    public uint ColorID;
    public sbyte Red;
    public sbyte Green;
    public sbyte Blue;
    [Cardinality(1)]
    public sbyte[] Padding60118179004 = new sbyte[1];
}
