// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum DataFieldVisibilityFlags
{
    None        = 0x000,
    Public      = 0x001,
    Private     = 0x002,
    Owner       = 0x004,
    Unused1     = 0x008,
    ItemOwner   = 0x010,
    SpecialInfo = 0x020,
    PartyMember = 0x040,
    UnitAll     = 0x080,
    Dynamic     = 0x100
}
