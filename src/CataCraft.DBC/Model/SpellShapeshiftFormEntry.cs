using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellShapeshiftForm.dbc")]
public sealed class SpellShapeshiftFormEntry
{
    [Index(false)]
    public uint ID;
    public int BonusActionBar;
    public string Name = string.Empty;
    public int Flags;
    public int CreatureType;
    public int AttackIconID;
    public int CombatRoundTime;
    [Cardinality(4)]
    public int[] CreatureDisplayID = new int[4];
    [Cardinality(8)]
    public int[] PresetSpellID = new int[8];
    public int MountTypeID;
    public int ExitSoundEntriesID;
}
