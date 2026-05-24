using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureFamily.dbc")]
public sealed class CreatureFamilyEntry
{
    [Index(false)]
    public uint ID;
    public float MinScale;
    public int MinScaleLevel;
    public float MaxScale;
    public int MaxScaleLevel;
    [Cardinality(2)]
    public int[] SkillLine = new int[2];
    public int PetFoodMask;
    public int PetTalentType;
    public int CategoryEnumID;
    public string Name = string.Empty;
    public string IconFile = string.Empty;
}
