// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

public enum WowGuidType : uint
{
    Item          = 0x400,
    Container     = 0x400,
    Player        = 0x000,
    GameObject    = 0xF11,
    Transport     = 0xF12,
    Unit          = 0xF13,
    Pet           = 0xF14,
    Vehicle       = 0xF15,
    DynamicObject = 0xF10,
    Corpse        = 0xF101,
    AreaTrigger   = 0xF102,
    BattleGround  = 0x1F1,
    Mo_Transport  = 0x1FC,
    Instance      = 0x1F4,
    Group         = 0x1F5,
    Guild         = 0x1FF
}
