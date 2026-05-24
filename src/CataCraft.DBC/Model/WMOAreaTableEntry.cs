using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WMOAreaTable.dbc")]
public sealed class WMOAreaTableEntry
{
    [Index(false)]
    public uint ID;
    public int WMOID;
    public int NameSetID;
    public int WMOGroupID;
    public int SoundProviderPref;
    public int SoundProviderPrefUnderwater;
    public int AmbienceID;
    public int ZoneMusic;
    public int IntroSound;
    public int Flags;
    public int AreaTableID;
    public string AreaName = string.Empty;
    public int UwIntroSound;
    public int UwZoneMusic;
    public int UwAmbience;
}
