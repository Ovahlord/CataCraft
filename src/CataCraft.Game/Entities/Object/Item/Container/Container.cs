// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.Item.Container;

public sealed class Container : Item
{
    public Container(WowGuid guid) : base(guid, (int)EContainerFields.CONTAINER_END, UpdateFieldConstants.SItemVisibilityFlags)
    {
    }
}
