using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CharStartOutfit.dbc")]
public sealed class CharStartOutfitEntry
{
    [Index(false)]
    public uint ID;
    public sbyte RaceID;
    public sbyte ClassID;
    public sbyte SexID;
    public sbyte OutfitID;
    [Cardinality(24)]
    public int[] ItemID = new int[24];
    [Cardinality(24)]
    public int[] DisplayItemID = new int[24];
    [Cardinality(24)]
    public int[] InventoryType = new int[24];
    public int PetDisplayID;
    public int PetFamilyID;
}
