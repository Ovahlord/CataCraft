using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaTable.dbc")]
public sealed class AreaTableEntry
{
    [Index(false)]
    public uint ID;
    public int ContinentID;
    public int ParentAreaID;
    public int AreaBit;
    public int Flags;
    public int SoundProviderPref;
    public int SoundProviderPrefUnderwater;
    public int AmbienceID;
    public int ZoneMusic;
    public int IntroSound;
    public int ExplorationLevel;
    public string AreaName = string.Empty;
    public int FactionGroupMask;
    [Cardinality(4)]
    public int[] LiquidTypeID = new int[4];
    public float MinElevation;
    public float AmbientMultiplier;
    public int LightID;
    public int MountFlags;
    public int UwIntroSound;
    public int UwZoneMusic;
    public int UwAmbience;
    public int WorldPvpID;
    public int PvpCombatWorldStateID;
}
