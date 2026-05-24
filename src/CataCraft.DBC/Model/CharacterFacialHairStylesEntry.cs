using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharacterFacialHairStyles.dbc")]
public sealed class CharacterFacialHairStylesEntry
{
    [Index(false)]
    public uint ID;
    public int RaceID;
    public int SexID;
    public int VariationID;
    [Cardinality(5)]
    public int[] Geoset = new int[5];
}
