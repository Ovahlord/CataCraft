// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Unit.Player;

public class VisibleItemEntry
{
    private readonly Player _owner;

    public VisibleItemEntry(Player owner)
    {
        _owner = owner;
    }

    public int this[InventorySlot slot]
    {
        get => _owner.GetInt32Value(EPlayerFields.PLAYER_VISIBLE_ITEM_1_ENTRYID + 2 * (int)slot);
        set => _owner.SetInt32Value(EPlayerFields.PLAYER_VISIBLE_ITEM_1_ENTRYID + 2 * (int)slot, 0, value);
    }
}
