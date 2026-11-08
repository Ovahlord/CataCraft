// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Unit.Player;

public class VisibleItemEnchantment
{
    private readonly Player _owner;

    public VisibleItemEnchantment(Player owner)
    {
        _owner = owner;
    }

    public short this[InventorySlot slot]
    {
        get => _owner.GetInt16Value(EPlayerFields.PLAYER_VISIBLE_ITEM_1_ENCHANTMENT + 2 * (int)slot);
        set => _owner.SetInt16Value(EPlayerFields.PLAYER_VISIBLE_ITEM_1_ENCHANTMENT + 2 * (int)slot, 0, 0, value);
    }
}
