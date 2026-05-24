using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ChrRaces.dbc")]
public sealed class ChrRacesEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public int FactionID;
    public int ExplorationSoundID;
    public int MaleDisplayID;
    public int FemaleDisplayID;
    public string ClientPrefix = string.Empty;
    public int BaseLanguage;
    public int CreatureType;
    public int ResSicknessSpellID;
    public int SplashSoundID;
    public string ClientFileString = string.Empty;
    public int CinematicSequenceID;
    public int Alliance;
    public string Name = string.Empty;
    public string NameFemale = string.Empty;
    public string NameMale = string.Empty;
    [Cardinality(2)]
    public string[] FacialHairCustomization = new string[2];
    public string HairCustomization = string.Empty;
    public int RaceRelated;
    public int UnalteredVisualRaceID;
    public int UaMaleCreatureSoundDataID;
    public int UaFemaleCreatureSoundDataID;
}
