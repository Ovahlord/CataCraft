// This file is part of the CataCraft project, which is published under the MIT license.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Item.Container;

public sealed class Container : Item
{
    private readonly ConcurrentDictionary<byte, Item> _items = [];

    #region Update Field Accessors

    public int NumSlots
    {
        get => GetInt32Value(EContainerFields.CONTAINER_FIELD_NUM_SLOTS);
        set => SetInt32Value(EContainerFields.CONTAINER_FIELD_NUM_SLOTS, 0, value);
    }

    #endregion

    public Container(WowGuid guid, int itemId) : base(guid, itemId, (int)EContainerFields.CONTAINER_END, UpdateFieldConstants.SItemVisibilityFlags)
    {
        ObjectType |= TypeMask.Container;
    }

    public bool TryGetItem(byte slot, [NotNullWhen(true)] out Item? item)
    {
        return _items.TryGetValue(slot, out item);
    }

    public void StoreItem(Item item, byte slot)
    {
        _items[slot] = item;
        SetUInt64Value(EContainerFields.CONTAINER_FIELD_SLOT_1, slot, item.Guid);
    }

    public Item? RemoveItem(byte slot)
    {
        if (_items.TryRemove(slot, out Item? item))
        {
            SetUInt64Value(EContainerFields.CONTAINER_FIELD_SLOT_1, slot, 0);
            return item;
        }

        return null;
    }

    /// <summary>
    /// Checks if the slot within this container contains any item
    /// </summary>
    /// <param name="slot">The slot within the container to check for an item</param>
    /// <returns>True if no item has been found in the slot, otherwise false</returns>
    public bool IsSlotEmpty(byte slot)
    {
        return _items.ContainsKey(slot);
    }
}
