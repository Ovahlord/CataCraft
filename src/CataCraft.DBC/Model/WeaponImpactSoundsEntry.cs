using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WeaponImpactSounds.dbc")]
public sealed class WeaponImpactSoundsEntry
{
    [Index(true)]
    public uint ID;
    public int WeaponSubClassID;
    public int ParrySoundType;
    [Cardinality(10)]
    public int[] ImpactSoundID = new int[10];
    [Cardinality(10)]
    public int[] CritImpactSoundID = new int[10];
}
