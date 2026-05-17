// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum MovementFlags0
{
    None               = 0,
    Forward            = 0x00000001,
    Backward           = 0x00000002,
    StrafeLeft         = 0x00000004,
    StrafeRight        = 0x00000008,
    Left               = 0x00000010,
    Right              = 0x00000020,
    PitchUp            = 0x00000040,
    PitchDown          = 0x00000080,
    Walking            = 0x00000100, // Walking
    DisableGravity     = 0x00000200, // Former MOVEMENTFLAG_LEVITATING. This is used when walking is not possible.
    Root               = 0x00000400, // Must not be set along with MOVEMENTFLAG_MASK_MOVING
    Falling            = 0x00000800, // damage dealt on that type of falling
    FallingFar         = 0x00001000,
    PendingStop        = 0x00002000,
    PendingStrafeStop  = 0x00004000,
    PendingForward     = 0x00008000,
    PendingBackward    = 0x00010000,
    PendingStrafeLeft  = 0x00020000,
    PendingStrafeRight = 0x00040000,
    PendingRoot        = 0x00080000,
    Swimming           = 0x00100000, // appears with fly flag also
    Ascending          = 0x00200000, // press "space" when flying or swimming
    Descending         = 0x00400000,
    CanFly             = 0x00800000, // Appears when unit can fly AND also walk
    Flying             = 0x01000000, // unit is actually flying. pretty sure this is only used for players
    SplineElevation    = 0x02000000, // used for flight paths
    Waterwalking       = 0x04000000, // prevent unit from falling through water
    FallingSlow        = 0x08000000, // active rogue safe fall spell (passive)
    Hover              = 0x10000000, // hover, cannot jump
    DisableCollision   = 0x20000000,
}
