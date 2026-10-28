using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DeathThudLookups.dbc")]
public sealed class DeathThudLookupsEntry
{
    [Index(true)]
    public uint ID;
    public int SizeClass;
    public int TerrainTypeSoundID;
    public int SoundEntryID;
    public int SoundEntryIDWater;
}
