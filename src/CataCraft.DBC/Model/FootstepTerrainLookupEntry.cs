using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FootstepTerrainLookup.dbc")]
public sealed class FootstepTerrainLookupEntry
{
    [Index(false)]
    public uint ID;
    public int CreatureFootstepID;
    public int TerrainSoundID;
    public int SoundID;
    public int SoundIDSplash;
}
