// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum MovementFlags1
{
    None                   = 0,
    NoStrafe               = 0x00000001,
    NoJumping              = 0x00000002,
    FullSpeedTurning       = 0x00000004,
    FullSpeedPitching      = 0x00000008,
    AlwaysAllowPitching    = 0x00000010,
    IsVehicleExitVoluntary = 0x00000020,
    Unk6                   = 0x00000040,
    Unk7                   = 0x00000080,
    Unk8                   = 0x00000100,
    Unk9                   = 0x00000200,
    CanSwimToFlyTrans      = 0x00000400,
    Unk11                  = 0x00000800,
    AwaitingLoad           = 0x00001000,
    InterpolatedMovement   = 0x00002000,
    InterpolatedTurning    = 0x00004000,
    InterpolatedPitching   = 0x00008000
}
