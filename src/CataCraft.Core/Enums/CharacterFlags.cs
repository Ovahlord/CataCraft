// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum CharacterFlags : int
{
    None                   = 0x00000000,
    InvisGod               = 0x00000001, // Player has God Invis enabled
    Resting                = 0x00000002, // Player is currently earning rest experience
    LockedForTransfer      = 0x00000004, // Player is locked - for paid character transfer
    Silenced               = 0x00000008, // Player's chat is silenced (can talk to GMs)
    UberinvisGod           = 0x00000010, // Player has God Uberinvis enabled
    Beastmaster            = 0x00000020, // Beastmaster is on
    PvpEnabled             = 0x00000040, // PvP Enabled
    PortAfterResurrect     = 0x00000080, // World port after resurrect
    ResetTalentsOnLogin    = 0x00000100, // Clear Talents on login
    HasPvpRank             = 0x00000200, // Player has a PvP Rank
    HideHelm               = 0x00000400, // Hide Helm
    HideCloak              = 0x00000800, // Hide Cloak
    Skinnable              = 0x00001000, // Player is skinnable
    Ghost                  = 0x00002000, // Player is a ghost
    Rename                 = 0x00004000, // Set to force a rename
    RenameNeedsGmReview    = 0x00008000, // Flag is set after rename for GM review
    PvpDesired             = 0x00010000, // PvP desired flag
    GmMode                 = 0x00020000, // GM Mode enabled
    DeletedByTransfer      = 0x00040000, // Deleted by a character transfer
    OnUnsafeTransport      = 0x00080000, // On unsafe transport (port to safe loc on log in)
    RenameFailed           = 0x00100000, // Player unable to rename character
    MountUpgraded          = 0x00200000, // Mount has been upgraded
    FriendsListNeedsRepair = 0x00400000, // Friends list requires a repair
    ExplorationDataFixed   = 0x00800000, // character had their exploration data fixed
    LockedByBilling        = 0x01000000, // Locked due to billing
    Declined               = 0x02000000, // Player has Russian declined name forms
    Commentator            = 0x04000000, // Commentator mode enabled
    UberCommentator        = 0x08000000, // Uber Commentator mode enabled
    XpFixed                = 0x10000000, // Player's XP has been fixed (2.2.x->2.3.0)
    LogPackets             = 0x20000000, // Log player packets
    CompensateForSpells    = 0x40000000 // Compensate for spells
}
