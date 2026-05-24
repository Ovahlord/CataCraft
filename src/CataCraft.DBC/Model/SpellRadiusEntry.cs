using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellRadius.dbc")]
public sealed class SpellRadiusEntry
{
    [Index(false)]
    public uint ID;
    public float Radius;
    public float RadiusPerLevel;
    public float RadiusMax;
}
