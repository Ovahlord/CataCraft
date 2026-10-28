using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TerrainTypeSounds.dbc")]
public sealed class TerrainTypeSoundsEntry
{
    [Index(true)]
    public uint ID;
}
