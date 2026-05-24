using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemPetFood.dbc")]
public sealed class ItemPetFoodEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
