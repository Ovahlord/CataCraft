// This file is part of the CataCraft project, which is published under the MIT license.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using CataCraft.Game.Entities.Object.Item.Container;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Protocol.Packets.GamePackets;

namespace CataCraft.Game.Entities.Object.Unit.Player;

/// <summary>
/// The class containing and managing all player items, currencies and money
/// </summary>
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
        if (slot < InventorySlot.Bag1)
        {
            _owner.VisibleItems[slot] = item.Entry;
            _owner.VisibleItemEnchantments[slot] = 0;
        }
    }

    /// <summary>
    /// Swaps the item at the slot A with the item at slot B. If no item exists in slot B the item in slot A will just
    /// be moved into the slot B.
    /// </summary>
    /// <param name="containerSlotA">The inventory slot of the container which contains the source item</param>
    /// <param name="slotA">The slot within the inventory or container which contains the source item</param>
    /// <param name="containerSlotB">The inventory slot of the container which contains the destination item/slot</param>
    /// <param name="slotB">The slot within the inventory or container which contains the source item/slot</param>
    public void SwapItem(InventorySlot containerSlotA, byte slotA, InventorySlot containerSlotB, byte slotB)
    {
        Console.WriteLine($"Attempting to move an item from slotA: {slotA} (containerA: {containerSlotA}) to slotB: {slotB} (containerB: {containerSlotB})");

        // Retrieve the source item and/or container
        Item.Item? sourceItem = null;
        Container? sourceContainer = null;
        if (containerSlotA == InventorySlot.BackPack)
        {
            if (!TryGetItem((InventorySlot)slotA, out sourceItem))
            {
                SendInventoryChangeFailure(BagResult.SlotEmpty);
                return;
            }
        }
        else if (!TryGetContainer(containerSlotA, out sourceContainer) || !sourceContainer.TryGetItem(slotA, out sourceItem))
        {
            SendInventoryChangeFailure(BagResult.SlotEmpty);
            return;
        }

        // Retrieve the destination item and/or container
        Item.Item? destItem = null;
        Container? destContainer = null;
        if (containerSlotB == InventorySlot.BackPack)
            TryGetItem((InventorySlot)slotB, out destItem);
        else
        {
            if (!TryGetContainer(containerSlotB, out destContainer))
                return;

            destContainer.TryGetItem(slotB, out destItem);
        }

        // Check if we are actually allowed to move both items to their destination
        if (!CheckItemSwapRequirements(sourceItem, sourceContainer, slotA, destItem, destContainer, slotB, out BagResult bagResult, out int itemLevel, out int limitCategory))
        {
            SendInventoryChangeFailure(bagResult, sourceItem, destItem, (byte)containerSlotB, itemLevel, slotA, limitCategory);
            return;
        }

        // Perform the swap. We first remove the source and dest item and store them in their opposite slots afterward
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

    /// <summary>
    /// Automatically equips the item in the specified slot into an appropriate equipment slot. Empty slots will be prioritized,
    /// otherwise the first available suitable slot will be selected
    /// </summary>
    /// <param name="slot">The inventory slot of the container which contains the item at the specified slot</param>
    /// <param name="packSlot">The slot within the specified container/inventory which contains the item to equip</param>
    public void AutoEquipItem(InventorySlot slot, byte packSlot)
    {
        if (slot == InventorySlot.BackPack)
        {
            if (TryGetItem((InventorySlot)packSlot, out Item.Item? item))
            {
                if (item.InventoryType == InventoryType.NonEquip)
                {
                    SendInventoryChangeFailure(BagResult.WrongSlot, item);
                    return;
                }

                if (FindAutoEquipmentSlotForItem(item, out InventorySlot equipmentSlot))
                    SwapItem(slot, packSlot, InventorySlot.BackPack, (byte)equipmentSlot);
                else
                    SendInventoryChangeFailure(BagResult.WrongSlot, item);
            }
            else
            {
                SendInventoryChangeFailure(BagResult.SlotEmpty);
            }
        }
        else
        {
            if (!TryGetContainer(slot, out Container? sourceContainer) || !sourceContainer.TryGetItem(packSlot, out Item.Item? item))
            {
                SendInventoryChangeFailure(BagResult.SlotEmpty);
                return;
            }

            if (item.InventoryType == InventoryType.NonEquip)
            {
                SendInventoryChangeFailure(BagResult.WrongSlot, item);
                return;
            }

            if (FindAutoEquipmentSlotForItem(item, out InventorySlot equipmentSlot))
                SwapItem(slot, packSlot, InventorySlot.BackPack, (byte)equipmentSlot);
            else
                SendInventoryChangeFailure(BagResult.WrongSlot, item);
        }
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

    /// <summary>
    /// Stores the item within the specified inventory slot. This method is used to move items into specified slots and
    /// does NOT perform any security checks. Use this method only when you are absolutely certain that the item belongs in
    /// the specified slot.
    /// </summary>
    /// <param name="item">The item to store in the specified slot</param>
    /// <param name="slot">The slot within the inventory to store the item in</param>
    public void StoreItem(Item.Item item, InventorySlot slot)
    {
        _items.TryAdd(slot, item);
        _owner.SetUInt64Value(EPlayerFields.PLAYER_FIELD_INV_SLOT_HEAD, (int)slot, item.Guid);
        if (slot < InventorySlot.Bag1)
        {
            _owner.VisibleItems[slot] = item.Entry;
            _owner.VisibleItemEnchantments[slot] = 0;
        }
    }

    public Item.Item? RemoveItem(InventorySlot slot)
    {
        if (_items.TryRemove(slot, out Item.Item? item))
        {
            _owner.SetUInt64Value(EPlayerFields.PLAYER_FIELD_INV_SLOT_HEAD, (int)slot, 0);
            if (slot < InventorySlot.Bag1)
            {
                _owner.VisibleItems[slot] = 0;
                _owner.VisibleItemEnchantments[slot] = 0;
            }
            return item;
        }

        return null;
    }

    public bool CheckItemSwapRequirements(Item.Item srcItem, Container? srcContainer, byte srcSlot, Item.Item? dstItem, Container? dstContainer, byte dstSlot, out BagResult bagResult, out int itemLevel, out int limitCategory)
    {
        bagResult = BagResult.Ok;
        itemLevel = 0;
        limitCategory = 0;

        // The player attempts swap the source item into an inventory slot. Make sure that the item belongs into the slot and meets the criterias
        if (dstContainer == null)
        {
            InventorySlot destination = (InventorySlot)dstSlot;

            // The player attempts to move the source item into an equipment slot. Check the item requirements like level, class and slot
            if (destination < InventorySlot.ItemStart)
            {
                if (!CheckEquipmentSlotRequirements(srcItem, destination, out bagResult, out itemLevel,
                        out limitCategory))
                    return false;
            }
        }

        if (srcContainer == null)
        {
            InventorySlot source = (InventorySlot)srcSlot;

            // Make sure that the item that we swap places with can also go into the new swap slot (i.e. Ring1 into Ring2 etc)
            if (source < InventorySlot.ItemStart)
            {
                if (dstItem != null && !CheckEquipmentSlotRequirements(dstItem, source, out bagResult, out itemLevel, out limitCategory))
                    return false;
            }
        }

        return true;
    }

    private bool CheckEquipmentSlotRequirements(Item.Item item, InventorySlot inventorySlot, out BagResult bagResult, out int itemLevel, out int limitCategory)
    {
        bagResult = BagResult.Ok;
        itemLevel = 0;
        limitCategory = 0;

        if (!item.CanGoInSlot(inventorySlot, false))
        {
            bagResult = BagResult.WrongSlot;
            return false;
        }

        //if (item.RequiredLevel > _owner.Level)
        //{
        //    itemLevel = item.RequiredLevel;
        //    bagResult = BagResult.CantEquipLevel;
        //    return false;
        //}

        return true;
    }

    public void SendInventoryChangeFailure(BagResult bagResult, Item.Item? srcItem = null, Item.Item? dstItem = null, byte containerBSlot = 0, int itemLevel = 0, int srcSlot = 0, int limitCategory = 0)
    {
        ServerInventoryChangeFailure inventoryChangeFailure = new()
        {
            BagResult = bagResult,
            Item =
            [
                srcItem?.Guid ?? WowGuid.Empty,
                dstItem?.Guid ?? WowGuid.Empty
            ],
            ContainerBSlot = containerBSlot,
            Level = itemLevel,
            SrcSlot = srcSlot,
            LimitCategory = limitCategory
        };

        _owner.Session?.EnqueuePacket(ref inventoryChangeFailure);
    }

    /// <summary>
    /// Checks if the slot within this container contains any item
    /// </summary>
    /// <param name="slot">The slot within the inventory to check for an item</param>
    /// <returns>True if no item has been found in the slot, otherwise false</returns>
    public bool IsSlotEmpty(InventorySlot slot)
    {
        return !_items.ContainsKey(slot);
    }

    public bool FindAutoEquipmentSlotForItem(Item.Item item, out InventorySlot slot)
    {
        for (slot = InventorySlot.Head; slot < InventorySlot.ItemStart; ++slot)
        {
            // First check if the item qualifies for the slot
            if (item.CanGoInSlot(slot, false))
            {
                // We accept any suitable empty slot right away
                if (IsSlotEmpty(slot))
                    return true;

                if (slot == InventorySlot.Finger1 || slot == InventorySlot.Trinket1 || slot == InventorySlot.Mainhand)
                {
                    // Try to find an alternative empty slot if the first suitable slot is used already
                    if (item.CanGoInSlot(slot + 1, false) && IsSlotEmpty(slot + 1))
                        slot += 1;
                }

                return true;
            }
        }

        return false;
    }
}
