// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;
using CataCraft.Game.World.Map;

namespace CataCraft.Game.Entities.Object;

public abstract class WorldObject : WowObject
{
    public MovementStatus MovementStatus { get; }
    public MapInstance? MapInstance { get; set; }

    protected WorldObject(WowGuid guid, int updateFieldCount, DataFieldVisibilityFlags[] updateFieldVisibilityFlags) : base(guid, updateFieldCount, updateFieldVisibilityFlags)
    {
        MovementStatus = new MovementStatus();
    }
}
