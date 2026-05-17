// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum RealmFlags
{
    None            = 0x0,
    VersionMismatch = 0x01,
    Offline         = 0x02,
    SpecifyBuild    = 0x04,
    Unk1            = 0x08,
    Unk2            = 0x10,
    NewPlayers      = 0x20,
    NewPlayers2     = 0x40,
    Full            = 0x80
}
