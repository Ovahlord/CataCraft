using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FootstepTerrainLookup.dbc")]
public sealed class FootstepTerrainLookupEntry
{
    [Index(true)]
    public uint ID;
    public int CreatureFootstepID;
    public int TerrainSoundID;
    public int SoundID;
    public int SoundIDSplash;
}
