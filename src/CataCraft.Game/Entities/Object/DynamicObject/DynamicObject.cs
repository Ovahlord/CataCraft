// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.DynamicObject;

public sealed class DynamicObject : WowObject
{
    public DynamicObject(WowGuid guid) : base(guid, (int)EDynamicObjectFields.DYNAMICOBJECT_END, [])
    {
    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }
}
