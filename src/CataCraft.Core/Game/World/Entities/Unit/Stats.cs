// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.World.Entities.Unit;

public sealed class Stats
{
    private static readonly float[] s_baseMovementSpeed =
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

    private readonly float[] _movementSpeedMultiplier =
    [
        1f, // MOVE_WALK
        1f, // MOVE_RUN
        1f, // MOVE_RUN_BACK
        1f, // MOVE_SWIM
        1f, // MOVE_SWIM_BACK
        1f, // MOVE_TURN_RATE
        1f, // MOVE_FLIGHT
        1f, // MOVE_FLIGHT_BACK
        1f // MOVE_PITCH_RATE
    ];

    public float WalkSpeed          { get { return s_baseMovementSpeed[(byte)MovementType.Walk] * _movementSpeedMultiplier[(byte)MovementType.Walk]; } }
    public float RunSpeed           { get { return s_baseMovementSpeed[(byte)MovementType.Run] * _movementSpeedMultiplier[(byte)MovementType.Run]; } }
    public float RunBackSpeed       { get { return s_baseMovementSpeed[(byte)MovementType.RunBack] * _movementSpeedMultiplier[(byte)MovementType.RunBack]; } }
    public float SwimSpeed          { get { return s_baseMovementSpeed[(byte)MovementType.Swim] * _movementSpeedMultiplier[(byte)MovementType.Swim]; } }
    public float SwimBackSpeed      { get { return s_baseMovementSpeed[(byte)MovementType.SwimBack] * _movementSpeedMultiplier[(byte)MovementType.SwimBack]; } }
    public float TurnRate           { get { return s_baseMovementSpeed[(byte)MovementType.TurnRate] * _movementSpeedMultiplier[(byte)MovementType.TurnRate]; } }
    public float FlightSpeed        { get { return s_baseMovementSpeed[(byte)MovementType.Flight] * _movementSpeedMultiplier[(byte)MovementType.Flight]; } }
    public float FlightBackSpeed    { get { return s_baseMovementSpeed[(byte)MovementType.FlightBack] * _movementSpeedMultiplier[(byte)MovementType.FlightBack]; } }
    public float PitchRate          { get { return s_baseMovementSpeed[(byte)MovementType.PitchRate] * _movementSpeedMultiplier[(byte)MovementType.PitchRate]; } }
}
