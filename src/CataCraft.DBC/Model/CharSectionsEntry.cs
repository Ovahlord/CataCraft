using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharSections.dbc")]
public sealed class CharSectionsEntry
{
    [Index(true)]
    public uint ID;
    public int RaceID;
    public int SexID;
    public int BaseSection;
    [Cardinality(3)]
    public string[] TextureName = new string[3];
    public int Flags;
    public int VariationIndex;
    public int ColorIndex;
}
