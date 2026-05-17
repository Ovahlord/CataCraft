// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum CharacterFlags2 : uint
{
    None                                = 0x00000000,
    Customize                           = 0x00000001, // Player has paid for a character re-customization
    GmSupporterProxy                    = 0x00000002, // GMSupportServer Proxy, NOT for GMTool use
    CanLoadOnNonShipTranport            = 0x00000004, // Character has been saved at least once since saving on non-ship transports was added
    BattleMasterMiscIsTaxiId            = 0x00000008, // Battle Master Misc Field is a Taxi ID
    TempPetAutocastSpell1               = 0x00000010, // Temp Pet Autocast Spell 1
    TempPetAutocastSpell2               = 0x00000020, // Temp Pet Autocast Spell 2
    TempPetAutocastSpell3               = 0x00000040, // Temp Pet Autocast Spell 3
    TempPetAutocastSpell4               = 0x00000080, // Temp Pet Autocast Spell 4
    TempPetAggressive                   = 0x00000100, // Temp Pet Aggressive
    TempPetPassive                      = 0x00000200, // Temp Pet Passive
    CanInteractWithOtherRealmsInSite    = 0x00000400, // Characters can interact with other realms in the site
    CanInteractWithOtherRealmsInRegion  = 0x00000800, // Characters can interact with other realms in the region
    BattleMasterMiscIsAreaId            = 0x00001000, // Battle Master Misc Field is an Area ID
    ReevaluateAccountItemLicenses       = 0x00002000, // Account Item Licenses must be reevaluated on next login
    BattleMasterMiscIsTransport         = 0x00004000, // Battle Master Misc Field is a Transport
    TalentsResetUsingTalentGroupData    = 0x00008000, // Players talents have been reset using talent group data
    FactionChange                       = 0x00010000, // This character is eligible to change his faction
    HasChangedRaceOrFaction             = 0x00020000, // This character has changed his race/faction and now requires the world server to repair him
    NoXpGain                            = 0x00040000, // This character has chosen to not gain XP by any means
    RecastOnResummon                    = 0x00080000, // Recast on Resummon
    RaceChange                          = 0x00100000, // This character is eligible to change his race
    ChangedTempPetAutocastSpell1        = 0x00200000, // Player has changed Temp Pet Autocast Spell 1
    ChangedTempPetAutocastSpell2        = 0x00400000, // Player has changed Temp Pet Autocast Spell 2
    ChangedTempPetAutocastSpell3        = 0x00800000, // Player has changed Temp Pet Autocast Spell 3
    ChangedTempPetAutocastSpell4        = 0x01000000, // Player has changed Temp Pet Autocast Spell 4
    ChangedGuildDuringCharacterTransfer = 0x02000000, // Player has transferred guilds during a PCT
    CanUseVoidStorageFeature            = 0x04000000, // Player is allowed to use the Void Storage feature
    BattlePetsConverted                 = 0x08000000, // Battle Pets Converted
    QuestsFixed                         = 0x10000000, // Player has had his quests fixed
    LowLevelRaidEnabled                 = 0x20000000, // The player can join raids even if he's below the min raid level
    AutoDeclineGuild                    = 0x40000000 // The player will automatically decline guild invites
}
