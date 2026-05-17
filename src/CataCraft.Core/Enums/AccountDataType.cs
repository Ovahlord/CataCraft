// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

public enum AccountDataType : byte
{
    GlobalConfigCache         = 0,
    PerCharacterConfigCache   = 1,
    GlobalBindingsCache       = 2,
    PerCharacterBindingsCache = 3,
    GlobalMacrosCache         = 4,
    PerCharacterMacrosCache   = 5,
    PerCharacterLayoutCache   = 6,
    PerCharacterChatCache     = 7,

    Max
}
