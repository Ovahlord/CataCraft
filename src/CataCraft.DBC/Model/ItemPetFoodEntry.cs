using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemPetFood.dbc")]
public sealed class ItemPetFoodEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
