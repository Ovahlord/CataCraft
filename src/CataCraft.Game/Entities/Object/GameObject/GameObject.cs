// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.GameObject;

public sealed class GameObject : WowObject
{
    public GameObject(WowGuid guid) : base(guid, (int)EGameObjectFields.GAMEOBJECT_END, [])
    {
    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }
}
