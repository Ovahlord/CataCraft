using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharSections.dbc")]
public sealed class CharSectionsEntry
{
    [Index(false)]
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
