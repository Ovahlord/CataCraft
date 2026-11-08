// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Item;

public class Item : WowObject
{
    // A bitmask array which allows us to determine which item goes into which slot via cheap operations
    private static readonly int[] s_inventoryTypeSlots =
    [
        0, //NonEquip
        1 << (int)InventorySlot.Head, // Head
        1 << (int)InventorySlot.Neck, // Neck
        1 << (int)InventorySlot.Shoulders, // Shoulders
        1 << (int)InventorySlot.Body,  // Body
        1 << (int)InventorySlot.Chest, // Chest
        1 << (int)InventorySlot.Waist, // Waist
        1 << (int)InventorySlot.Legs, // Legs
        1 << (int)InventorySlot.Feet, // Feet
        1 << (int)InventorySlot.Wrists,// Wrists
        1 << (int)InventorySlot.Hands, // Hands
        1 << (int)InventorySlot.Finger1 | 1 << (int)InventorySlot.Finger2, // Finger
        1 << (int)InventorySlot.Trinket1 | 1 << (int)InventorySlot.Trinket2, // Trinket
        1 << (int)InventorySlot.Mainhand | 1 << (int)InventorySlot.Offhand, // Weapon
        1 << (int)InventorySlot.Offhand, // Shield
        1 << (int)InventorySlot.Ranged, // Ranged
        1 << (int)InventorySlot.Back, // Cloak
        1 << (int)InventorySlot.Mainhand | 1 << (int)InventorySlot.Offhand,  // TwoHandedWeapon
        1 << (int)InventorySlot.Bag1 | 1 << (int)InventorySlot.Bag2 | 1 << (int)InventorySlot.Bag3 | 1 << (int)InventorySlot.Bag4, // Bag
        1 << (int)InventorySlot.Tabard, // Tabard
        1 << (int)InventorySlot.Chest, // Robe
        1 << (int)InventorySlot.Mainhand | 1 << (int)InventorySlot.Offhand, // WeaponMainhand
        1 << (int)InventorySlot.Mainhand | 1 << (int)InventorySlot.Offhand, //WeaponOffhand
        1 << (int)InventorySlot.Offhand, //Holdable
        0, //Ammo - No longer used in Cataclysm
        1 << (int)InventorySlot.Ranged, //Thrown
        1 << (int)InventorySlot.Ranged, //RangedRight
        0, //Quiver - No longer used in Cataclysm
        1 << (int)InventorySlot.Ranged, //Relic
    ];

    private readonly ItemSparseEntry? _itemSparseEntry;
    private readonly ItemEntry? _itemEntry;

    // Properties
    public InventoryType InventoryType => (InventoryType)(_itemEntry?.InventoryType ?? (int)InventoryType.NonEquip);
    public ChrClass ClassId => (ChrClass)(_itemEntry?.ClassID ?? (int)ChrClass.None);
    public int RequiredLevel => (int)(_itemSparseEntry?.RequiredLevel ?? 0);

    #region Update Field Accessors

    public WowGuid Owner
    {
        get => GetUInt64Value(EItemFields.ITEM_FIELD_OWNER);
        set => SetUInt64Value(EItemFields.ITEM_FIELD_OWNER, 0, value);
    }

    public WowGuid Contained
    {
        get => GetUInt64Value(EItemFields.ITEM_FIELD_CONTAINED);
        set => SetUInt64Value(EItemFields.ITEM_FIELD_CONTAINED, 0, value);
    }

    public WowGuid Creator
    {
        get => GetUInt64Value(EItemFields.ITEM_FIELD_CREATOR);
        set => SetUInt64Value(EItemFields.ITEM_FIELD_CREATOR, 0, value);
    }

    public WowGuid GiftCreator
    {
        get => GetUInt64Value(EItemFields.ITEM_FIELD_GIFTCREATOR);
        set => SetUInt64Value(EItemFields.ITEM_FIELD_GIFTCREATOR, 0, value);
    }

    public int StackCount
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_STACK_COUNT);
        set => SetInt32Value(EItemFields.ITEM_FIELD_STACK_COUNT, 0, value);
    }

    public int Duration
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_DURATION);
        set => SetInt32Value(EItemFields.ITEM_FIELD_DURATION, 0, value);
    }

    public int SpellCharges
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_SPELL_CHARGES);
        set => SetInt32Value(EItemFields.ITEM_FIELD_SPELL_CHARGES, 0, value);
    }

    public int Flags
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_FLAGS);
        set => SetInt32Value(EItemFields.ITEM_FIELD_FLAGS, 0, value);
    }

    public int PropertySeed
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_PROPERTY_SEED);
        set => SetInt32Value(EItemFields.ITEM_FIELD_PROPERTY_SEED, 0, value);
    }

    public int RandomPropertiesId
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_RANDOM_PROPERTIES_ID);
        set => SetInt32Value(EItemFields.ITEM_FIELD_RANDOM_PROPERTIES_ID, 0, value);
    }

    public int Durability
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_DURABILITY);
        set => SetInt32Value(EItemFields.ITEM_FIELD_DURABILITY, 0, value);
    }

    public int MaxDurability
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_MAXDURABILITY);
        set => SetInt32Value(EItemFields.ITEM_FIELD_MAXDURABILITY, 0, value);
    }

    public int CreatePlayedTime
    {
        get => GetInt32Value(EItemFields.ITEM_FIELD_CREATE_PLAYED_TIME);
        set => SetInt32Value(EItemFields.ITEM_FIELD_CREATE_PLAYED_TIME, 0, value);
    }

    #endregion // Update Field Accessors

    public Item(WowGuid guid, int itemId) : base(guid, (int)EItemFields.ITEM_END, UpdateFieldConstants.SItemVisibilityFlags)
    {
        ObjectType |= TypeMask.Item;
        Entry = itemId;

        DBCManager.SItemSparseStore.TryGetValue(itemId, out _itemSparseEntry);
        DBCManager.SItemStore.TryGetValue(itemId, out _itemEntry);
    }

    public Item(WowGuid guid, int itemId, int updateFieldCount, UpdateFieldVisibilityFlags[] updateFieldVisibilityFlags) : base(guid, updateFieldCount, updateFieldVisibilityFlags)
    {
        ObjectType |= TypeMask.Item;
        Entry = itemId;

        DBCManager.SItemSparseStore.TryGetValue(itemId, out _itemSparseEntry);
        DBCManager.SItemStore.TryGetValue(itemId, out _itemEntry);
    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }

    public bool CanGoInSlot(InventorySlot slot, bool allowRelic)
    {
        // Ranged weapon slot check
        if (slot == InventorySlot.Ranged)
        {
            if (allowRelic != (InventoryType == InventoryType.Relic))
                return false;

            return CanInventoryTypeGoIntoSlot(InventoryType, slot);
        }

        // Non-Weapon checks
        if ((slot != InventorySlot.Mainhand && slot != InventorySlot.Offhand) || ClassId != ChrClass.Paladin)
        {
            // Items can always go into backpack slots
            if (slot >= InventorySlot.ItemStart)
                return true;

            return CanInventoryTypeGoIntoSlot(InventoryType, slot);
        }

        // Weapon checks
        if (slot == InventorySlot.Offhand)
        {
            if (InventoryType != InventoryType.TwoHandedWeapon && InventoryType != InventoryType.WeaponMainhand)
                CanInventoryTypeGoIntoSlot(InventoryType, slot);
        }
        else if (InventoryType != InventoryType.WeaponOffhand)
            return CanInventoryTypeGoIntoSlot(InventoryType, slot);

        //if ((stats->m_flags[0] & 0x40000000) || rec->m_subclassID == 13)
        //    return false;

        return false;
    }

    public static bool CanInventoryTypeGoIntoSlot(InventoryType inventoryType, InventorySlot inventorySlot)
    {
        return (s_inventoryTypeSlots[(int)inventoryType] & (1 << (int)inventorySlot)) != 0;
    }
}
