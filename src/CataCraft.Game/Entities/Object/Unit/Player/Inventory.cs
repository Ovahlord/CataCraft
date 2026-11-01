// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Unit.Player;

public class Inventory
{
    private readonly Dictionary<InventorySlot, Item.Item?> _items = [];
    private readonly Player _owner;

    public Inventory(Player owner)
    {
        _owner = owner;
    }

    public void EquipItem(Item.Item item, InventorySlot slot)
    {
        _items.TryAdd(slot, item);
        _owner.SetUInt64Value(EPlayerFields.PLAYER_FIELD_INV_SLOT_HEAD, (int)slot, item.Guid);
    }
}
