using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldChunkSounds.dbc")]
public sealed class WorldChunkSoundsEntry
{
    [Index(false)]
    public uint ID;
    public int WorldMapContinentID;
    public int ChunkX;
    public int ChunkY;
    public int SubchunkX;
    public int SubchunkY;
    public int ZoneIntroMusicID;
    public int ZoneMusicID;
    public int SoundAmbienceID;
    public int SoundProviderPreferencesID;
}
