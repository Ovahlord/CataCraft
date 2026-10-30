// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Entities.Object;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Unit.Unit;


public sealed class Unit : UnitBase
{
    public Unit(WowGuid guid) : base(guid, (int)EUnitFields.UNIT_END, UpdateFieldConstants.SUnitVisibilityFlags)
    {

    }

    public override void Update()
    {
    }

    public override void Heartbeat()
    {
    }
}
