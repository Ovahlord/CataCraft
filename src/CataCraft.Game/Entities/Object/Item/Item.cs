// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Item;

public class Item : WowObject
{
    public Item(WowGuid guid) : base(guid, (int)EItemFields.ITEM_END, [])
    {
        ObjectType |= TypeMask.Item;
    }

    public Item(WowGuid guid, int updateFieldCount, DataFieldVisibilityFlags[] updateFieldVisibilityFlags) : base(guid, updateFieldCount, updateFieldVisibilityFlags)
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
