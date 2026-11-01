// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Realm.Entities;

[PrimaryKey(nameof(CharacterId), nameof(ItemInstanceId), nameof(InventorySlot))]
public class CharacterInventory
{
    public int CharacterId { get; set; }
    public int ItemInstanceId { get; set; }
    public int InventorySlot { get; set; }

    // Navigation property
    public Character Character { get; set; } = null!;
    public ItemInstance Item { get; set; } = null!;
}
