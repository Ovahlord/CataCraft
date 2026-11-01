// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object.AreaTrigger;

public class AreaTrigger : WowObject
{
    public AreaTrigger(WowGuid guid) : base(guid, (int)EAreaTriggerFields.AREATRIGGER_END, [])
    {
    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }
}
