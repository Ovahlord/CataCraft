using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldStateZoneSounds.dbc")]
public sealed class WorldStateZoneSoundsEntry
{
    [Index(true)]
    public uint ID;
    public int WorldStateID;
    public int WorldStateValue;
    public int AreaID;
    public int WMOAreaID;
    public int ZoneIntroMusicID;
    public int ZoneMusicID;
    public int SoundAmbienceID;
    public int SoundProviderPreferencesID;
}
