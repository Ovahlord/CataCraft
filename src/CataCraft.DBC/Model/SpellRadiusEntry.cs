using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellRadius.dbc")]
public sealed class SpellRadiusEntry
{
    [Index(true)]
    public uint ID;
    public float Radius;
    public float RadiusPerLevel;
    public float RadiusMax;
}
