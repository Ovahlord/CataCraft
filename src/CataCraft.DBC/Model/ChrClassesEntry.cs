using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ChrClasses.dbc")]
public sealed class ChrClassesEntry
{
    [Index(false)]
    public uint ID;
    public int DisplayPower;
    public string PetNameToken = string.Empty;
    public string Name = string.Empty;
    public string NameFemale = string.Empty;
    public string NameMale = string.Empty;
    public string Filename = string.Empty;
    public int SpellClassSet;
    public int Flags;
    public int CinematicSequenceID;
    public int RequiredExpansion;
    public int AttackPowerPerStrength;
    public int AttackPowerPerAgility;
    public int RangedAttackPowerPerAgility;
}
