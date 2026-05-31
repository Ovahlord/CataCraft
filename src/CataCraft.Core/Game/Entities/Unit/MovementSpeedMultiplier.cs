// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.Entities.Unit;

public class MovementSpeedMultiplier
{
    private float[] _multipliers =
    [
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
    ];

    private readonly Unit _owner;

    public MovementSpeedMultiplier(Unit owner) => _owner = owner;

    public float this[MovementType movementType]
    {
        get =>  _multipliers[(int)movementType];
        set =>  _multipliers[(int)movementType] = value;
    }
}
