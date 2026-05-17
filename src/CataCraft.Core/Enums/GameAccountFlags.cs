// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum GameAccountFlags : uint
{
    None                               = 0x00000000,
    GameAccountFlagGm                  = 0x00000001,
    GameAccountFlagNoKick              = 0x00000002,
    GameAccountFlagCollector           = 0x00000004,
    GameAccountFlagWowTrial            = 0x00000008,
    GameAccountFlagCancelled           = 0x00000010,
    GameAccountFlagIgr                 = 0x00000020,
    GameAccountFlagWholesaler          = 0x00000040,
    GameAccountFlagPrivileged          = 0x00000080,
    GameAccountFlagEuForbidElv         = 0x00000100,
    GameAccountFlagEuForbidBilling     = 0x00000200,
    GameAccountFlagWowRestricted       = 0x00000400,
    GameAccountFlagReferral            = 0x00000800,
    GameAccountFlagBlizzard            = 0x00001000,
    GameAccountFlagRecurringBilling    = 0x00002000,
    GameAccountFlagNoElectUp           = 0x00004000,
    GameAccountFlagKrCertificate       = 0x00008000,
    GameAccountFlagExpansionCollector  = 0x00010000,
    GameAccountFlagDisableVoice        = 0x00020000,
    GameAccountFlagDisableVoiceSpeak   = 0x00040000,
    GameAccountFlagReferralResurrect   = 0x00080000,
    GameAccountFlagEuForbidCc          = 0x00100000,
    GameAccountFlagOpenBetaDell        = 0x00200000,
    GameAccountFlagPropass             = 0x00400000,
    GameAccountFlagPropassLock         = 0x00800000,
    GameAccountFlagPendingUpgrade      = 0x01000000,
    GameAccountFlagRetailFromTrial     = 0x02000000,
    GameAccountFlagExpansion2Collector = 0x04000000,
    GameAccountFlagOvermindLinked      = 0x08000000,
    GameAccountFlagDemos               = 0x10000000,
    GameAccountFlagDeathKnightOk       = 0x20000000,
}
