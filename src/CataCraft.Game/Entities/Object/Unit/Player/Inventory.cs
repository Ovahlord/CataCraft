// This file is part of the CataCraft project, which is published under the MIT license.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using CataCraft.Game.Entities.Object.Item.Container;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Unit.Player;

public class Inventory
{
    private readonly ConcurrentDictionary<InventorySlot, Item.Item?> _items = [];
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

    public void SwapItem(InventorySlot containerSlotA, byte slotA, InventorySlot containerSlotB, byte slotB)
    {
        Console.WriteLine($"Attempting to move an item from slotA: {slotA} (containerA: {containerSlotA}) to slotB: {slotB} (containerB: {containerSlotB})");

        // Retrieve the source item and container
        Item.Item? sourceItem = null;
        Container? sourceContainer = null;
        if (containerSlotA == InventorySlot.BackPack)
        {
            if (!TryGetItem((InventorySlot)slotA, out sourceItem))
                return;
        }
        else if (!TryGetContainer(containerSlotA, out sourceContainer) ||
                 !sourceContainer.TryGetItem(slotA, out sourceItem))
            return;

        // Retrieve the destination item and/or container
        Item.Item? destItem = null;
        Container? destContainer = null;

        if (containerSlotB == InventorySlot.BackPack)
            TryGetItem((InventorySlot)slotB, out destItem);
        else
        {
            if (!TryGetContainer(containerSlotB, out destContainer))
                return;
        }

        // Remove the items from destination and target
        if (sourceContainer != null)
            sourceContainer.RemoveItem(slotA);
        else
            RemoveItem((InventorySlot)slotA);

        if (destContainer != null)
            destContainer.RemoveItem(slotB);
        else
            RemoveItem((InventorySlot)slotA);

        // Store the flipped items
        if (destItem != null)
        {
            if (sourceContainer != null)
                sourceContainer.StoreItem(destItem, slotA);
            else
                StoreItem(destItem, (InventorySlot)slotA);
        }

        if (destContainer != null)
            destContainer.StoreItem(sourceItem, slotB);
        else
            StoreItem(sourceItem, (InventorySlot)slotB);
    }

    public bool TryGetItem(InventorySlot slot, [NotNullWhen(true)] out Item.Item? item)
    {
        return _items.TryGetValue(slot, out item);
    }

    public bool TryGetContainer(InventorySlot containerSlot, [NotNullWhen(true)] out Container? container)
    {
        container = null;

        if (containerSlot < InventorySlot.Bag1 || containerSlot > InventorySlot.Bag4)
            return false;

        if (_items.TryGetValue(containerSlot, out Item.Item? item))
        {
            if (item is Container c)
            {
                container = c;
                return true;
            }
        }

        return false;
    }

    public void StoreItem(Item.Item item, InventorySlot slot)
    {
        _items.TryAdd(slot, item);
        _owner.SetUInt64Value(EPlayerFields.PLAYER_FIELD_INV_SLOT_HEAD, (int)slot, item.Guid);
    }

    public Item.Item? RemoveItem(InventorySlot slot)
    {
        if (_items.TryRemove(slot, out Item.Item? item))
        {
            _owner.SetUInt64Value(EPlayerFields.PLAYER_FIELD_INV_SLOT_HEAD, (int)slot, 0);
            return item;
        }

        return null;
    }
}
