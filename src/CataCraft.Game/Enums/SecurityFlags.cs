// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Game.Enums;

[Flags]
public enum SecurityFlags : byte
{
    None          = 0,
    Pin           = 0x1,
    MatrixCard    = 0x2,
    Authenticator = 0x4
}
