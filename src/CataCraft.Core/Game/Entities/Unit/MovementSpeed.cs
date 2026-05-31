// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.Entities.Unit;

public class MovementSpeed
{
    private static readonly float[] s_baseMovementSpeeds =
    [
        2.5f, // MOVE_WALK
        7.0f, // MOVE_RUN
        4.5f, // MOVE_RUN_BACK
        4.722222f, // MOVE_SWIM
        2.5f, // MOVE_SWIM_BACK
        3.141594f, // MOVE_TURN_RATE
        7.0f, // MOVE_FLIGHT
        4.5f, // MOVE_FLIGHT_BACK
        3.14f // MOVE_PITCH_RATE
    ];

    private readonly Unit _owner;

    public MovementSpeed(Unit owner) => _owner = owner;

    public float this[MovementType movementType] => s_baseMovementSpeeds[(int)movementType] * _owner.MovementSpeedMultiplier[movementType];

}
