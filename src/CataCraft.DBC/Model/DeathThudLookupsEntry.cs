using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DeathThudLookups.dbc")]
public sealed class DeathThudLookupsEntry
{
    [Index(false)]
    public uint ID;
    public int SizeClass;
    public int TerrainTypeSoundID;
    public int SoundEntryID;
    public int SoundEntryIDWater;
}
