using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharBaseInfo.dbc")]
public sealed class CharBaseInfoEntry
{
    [Index(true)]
    public uint ID;
    public sbyte RaceID;
    public sbyte ClassID;
    [Cardinality(2)]
    public sbyte[] Padding40011792003 = new sbyte[2];
}
