using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TerrainTypeSounds.dbc")]
public sealed class TerrainTypeSoundsEntry
{
    [Index(false)]
    public uint ID;
}
