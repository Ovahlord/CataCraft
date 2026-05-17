// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum AuthResult : byte
{
    WowSuccess                         = 0x00,
    WowFailBanned                      = 0x03,
    WowFailUnknownAccount              = 0x04,
    WowFailIncorrectPassword           = 0x05,
    WowFailAlreadyOnline               = 0x06,
    WowFailNoTime                      = 0x07,
    WowFailDbBusy                      = 0x08,
    WowFailVersionInvalid              = 0x09,
    WowFailVersionUpdate               = 0x0A,
    WowFailInvalidServer               = 0x0B,
    WowFailSuspended                   = 0x0C,
    WowFailFailNoaccess                = 0x0D,
    WowSuccessSurvey                   = 0x0E,
    WowFailParentcontrol               = 0x0F,
    WowFailLockedEnforced              = 0x10,
    WowFailTrialEnded                  = 0x11,
    WowFailUseBattlenet                = 0x12,
    WowFailAntiIndulgence              = 0x13,
    WowFailExpired                     = 0x14,
    WowFailNoGameAccount               = 0x15,
    WowFailChargeback                  = 0x16,
    WowFailInternetGameRoomWithoutBnet = 0x17,
    WowFailGameAccountLocked           = 0x18,
    WowFailUnlockableLock              = 0x19,
    WowFailConversionRequired          = 0x20,
    WowFailDisconnected                = 0xFF
}
