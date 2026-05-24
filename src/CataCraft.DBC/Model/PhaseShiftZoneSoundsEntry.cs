using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PhaseShiftZoneSounds.dbc")]
public sealed class PhaseShiftZoneSoundsEntry
{
    [Index(false)]
    public uint ID;
    public int AreaID;
    public int WMOAreaID;
    public int PhaseID;
    public int PhaseGroupID;
    public int PhaseUseFlags;
    public int ZoneIntroMusicID;
    public int ZoneMusicID;
    public int SoundAmbienceID;
    public int SoundProviderPreferencesID;
    public int UWZoneIntroMusicID;
    public int UWZoneMusicID;
    public int UWSoundAmbienceID;
    public int UWSoundProviderPreferencesID;
}
