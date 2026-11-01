// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Item;

public class Item : WowObject
{
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

    public Item(WowGuid guid) : base(guid, (int)EItemFields.ITEM_END, UpdateFieldConstants.SItemVisibilityFlags)
    {
        ObjectType |= TypeMask.Item;
    }

    public Item(WowGuid guid, int updateFieldCount, UpdateFieldVisibilityFlags[] updateFieldVisibilityFlags) : base(guid, updateFieldCount, updateFieldVisibilityFlags)
    {
        ObjectType |= TypeMask.Item;
    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }
}
