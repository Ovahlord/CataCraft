// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object;

public static class UpdateFieldConstants
{
    public static readonly UpdateFieldVisibilityFlags[] SUnitVisibilityFlags =
    [
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID+1
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA+1
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_TYPE
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_ENTRY
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_SCALE_X
        UpdateFieldVisibilityFlags.None,                                           // OBJECT_FIELD_PADDING
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON+1
        UpdateFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER
        UpdateFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_CHANNEL_SPELL
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_0
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HEALTH
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER3
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER4
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER5
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXHEALTH
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER3
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER4
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+4
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_LEVEL
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FACTIONTEMPLATE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS_2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_AURASTATE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME+1
        UpdateFieldVisibilityFlags.Private,                                        // UNIT_FIELD_RANGEDATTACKTIME
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BOUNDINGRADIUS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_COMBATREACH
        UpdateFieldVisibilityFlags.Dynamic,                                        // UNIT_FIELD_DISPLAYID
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_NATIVEDISPLAYID
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MOUNTDISPLAYID
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINOFFHANDDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXOFFHANDDAMAGE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PETNUMBER
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PET_NAME_TIMESTAMP
        UpdateFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETEXPERIENCE
        UpdateFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETNEXTLEVELEXP
        UpdateFieldVisibilityFlags.Dynamic,                                        // UNIT_DYNAMIC_FLAGS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_SPEED
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_HASTE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_CREATED_BY_SPELL
        UpdateFieldVisibilityFlags.Dynamic,                                        // UNIT_NPC_FLAGS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_NPC_EMOTESTATE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT0
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT0
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT0
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+6
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASE_MANA
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_BASE_HEALTH
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_POS
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_NEG
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MULTIPLIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MINRANGEDDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXRANGEDDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXHEALTHMODIFIER
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HOVERHEIGHT
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXITEMLEVEL
        UpdateFieldVisibilityFlags.None                                            // UNIT_FIELD_PADDING
    ];

    public static readonly UpdateFieldVisibilityFlags[] SPlayerVisibilityFlags =
    [
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID+1
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA+1
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_TYPE
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_ENTRY
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_SCALE_X
        UpdateFieldVisibilityFlags.None,                                           // OBJECT_FIELD_PADDING
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON+1
        UpdateFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER
        UpdateFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_CHANNEL_SPELL
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_0
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HEALTH
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER3
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER4
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER5
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXHEALTH
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER3
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER4
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+4
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_LEVEL
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FACTIONTEMPLATE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS_2
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_AURASTATE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME+1
        UpdateFieldVisibilityFlags.Private,                                        // UNIT_FIELD_RANGEDATTACKTIME
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BOUNDINGRADIUS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_COMBATREACH
        UpdateFieldVisibilityFlags.Dynamic,                                        // UNIT_FIELD_DISPLAYID
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_NATIVEDISPLAYID
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MOUNTDISPLAYID
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINOFFHANDDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXOFFHANDDAMAGE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_1
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PETNUMBER
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PET_NAME_TIMESTAMP
        UpdateFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETEXPERIENCE
        UpdateFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETNEXTLEVELEXP
        UpdateFieldVisibilityFlags.Dynamic,                                        // UNIT_DYNAMIC_FLAGS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_SPEED
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_HASTE
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_CREATED_BY_SPELL
        UpdateFieldVisibilityFlags.Dynamic,                                        // UNIT_NPC_FLAGS
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_NPC_EMOTESTATE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT0
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT0
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT0
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+6
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASE_MANA
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_BASE_HEALTH
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_POS
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_NEG
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MULTIPLIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MINRANGEDDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXRANGEDDAMAGE
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+1
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+2
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+3
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+4
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+5
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+6
        UpdateFieldVisibilityFlags.Private | UpdateFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXHEALTHMODIFIER
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HOVERHEIGHT
        UpdateFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXITEMLEVEL
        UpdateFieldVisibilityFlags.None,                                            // UNIT_FIELD_PADDING
        UpdateFieldVisibilityFlags.Public, // PLAYER_DUEL_ARBITER
        UpdateFieldVisibilityFlags.Public, // PLAYER_DUEL_ARBITER+1
        UpdateFieldVisibilityFlags.Public, // PLAYER_FLAGS
        UpdateFieldVisibilityFlags.Public, // PLAYER_GUILDRANK
        UpdateFieldVisibilityFlags.Public, // PLAYER_GUILDDELETE_DATE
        UpdateFieldVisibilityFlags.Public, // PLAYER_GUILDLEVEL
        UpdateFieldVisibilityFlags.Public, // PLAYER_BYTES
        UpdateFieldVisibilityFlags.Public, // PLAYER_BYTES_2
        UpdateFieldVisibilityFlags.Public, // PLAYER_BYTES_3
        UpdateFieldVisibilityFlags.Public, // PLAYER_DUEL_TEAM
        UpdateFieldVisibilityFlags.Public, // PLAYER_GUILD_TIMESTAMP
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_4
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_5
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_2
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_3
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_3+1
        UpdateFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_5
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_1_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_1_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_2_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_2_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_3_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_3_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_4_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_4_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_5_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_5_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_6_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_6_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_7_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_7_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_8_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_8_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_9_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_9_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_10_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_10_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_11_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_11_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_12_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_12_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_13_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_13_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_14_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_14_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_15_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_15_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_16_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_16_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_17_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_17_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_18_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_18_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_19_ENTRYID
        UpdateFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_19_ENCHANTMENT
        UpdateFieldVisibilityFlags.Public, // PLAYER_CHOSEN_TITLE
        UpdateFieldVisibilityFlags.Public, // PLAYER_FAKE_INEBRIATION
        UpdateFieldVisibilityFlags.None, // PLAYER_FIELD_PAD_0
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_FARSIGHT
        UpdateFieldVisibilityFlags.Private, // PLAYER_FARSIGHT+1
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES+1
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES1
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES2
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES2+1
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES3
        UpdateFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES3+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_XP
        UpdateFieldVisibilityFlags.Private, // PLAYER_NEXT_LEVEL_XP
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+56
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+57
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+58
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+59
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+60
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+61
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+62
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+63
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+56
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+57
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+58
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+59
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+60
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+61
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+62
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+63
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+56
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+57
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+58
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+59
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+60
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+61
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+62
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+63
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+56
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+57
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+58
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+59
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+60
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+61
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+62
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+63
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+56
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+57
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+58
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+59
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+60
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+61
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+62
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+63
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+56
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+57
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+58
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+59
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+60
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+61
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+62
        UpdateFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+63
        UpdateFieldVisibilityFlags.Private, // PLAYER_CHARACTER_POINTS
        UpdateFieldVisibilityFlags.Private, // PLAYER_TRACK_CREATURES
        UpdateFieldVisibilityFlags.Private, // PLAYER_TRACK_RESOURCES
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPERTISE
        UpdateFieldVisibilityFlags.Private, // PLAYER_OFFHAND_EXPERTISE
        UpdateFieldVisibilityFlags.Private, // PLAYER_BLOCK_PERCENTAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_DODGE_PERCENTAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_PARRY_PERCENTAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_CRIT_PERCENTAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_RANGED_CRIT_PERCENTAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_OFFHAND_CRIT_PERCENTAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_SHIELD_BLOCK
        UpdateFieldVisibilityFlags.Private, // PLAYER_SHIELD_BLOCK_CRIT_PERCENTAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_MASTERY
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+26
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+27
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+28
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+29
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+30
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+31
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+32
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+33
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+34
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+35
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+36
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+37
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+38
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+39
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+40
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+41
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+42
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+43
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+44
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+45
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+46
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+47
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+48
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+49
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+50
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+51
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+52
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+53
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+54
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+55
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+56
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+57
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+58
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+59
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+60
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+61
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+62
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+63
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+64
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+65
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+66
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+67
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+68
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+69
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+70
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+71
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+72
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+73
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+74
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+75
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+76
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+77
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+78
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+79
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+80
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+81
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+82
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+83
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+84
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+85
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+86
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+87
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+88
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+89
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+90
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+91
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+92
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+93
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+94
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+95
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+96
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+97
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+98
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+99
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+100
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+101
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+102
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+103
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+104
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+105
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+106
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+107
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+108
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+109
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+110
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+111
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+112
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+113
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+114
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+115
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+116
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+117
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+118
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+119
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+120
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+121
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+122
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+123
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+124
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+125
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+126
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+127
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+128
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+129
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+130
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+131
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+132
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+133
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+134
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+135
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+136
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+137
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+138
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+139
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+140
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+141
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+142
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+143
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+144
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+145
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+146
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+147
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+148
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+149
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+150
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+151
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+152
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+153
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+154
        UpdateFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+155
        UpdateFieldVisibilityFlags.Private, // PLAYER_REST_STATE_EXPERIENCE
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COINAGE
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COINAGE+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HEALING_DONE_POS
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HEALING_PCT
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HEALING_DONE_PCT
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_WEAPON_DMG_MULTIPLIERS
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_WEAPON_DMG_MULTIPLIERS+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_WEAPON_DMG_MULTIPLIERS+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_SPELL_POWER_PCT
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_OVERRIDE_SPELL_POWER_BY_AP_PCT
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_TARGET_RESISTANCE
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BYTES
        UpdateFieldVisibilityFlags.Private, // PLAYER_SELF_RES_SPELL
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_PVP_MEDALS
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_KILLS
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_LIFETIME_HONORBALE_KILLS
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BYTES2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_WATCHED_FACTION_INDEX
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+25
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_BATTLEGROUND_RATING
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MAX_LEVEL
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+9
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+10
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+11
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+12
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+13
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+14
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+15
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+16
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+17
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+18
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+19
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+20
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+21
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+22
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+23
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+24
        UpdateFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_NO_REAGENT_COST_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_NO_REAGENT_COST_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_NO_REAGENT_COST_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+8
        UpdateFieldVisibilityFlags.Private, // PLAYER_GLYPHS_ENABLED
        UpdateFieldVisibilityFlags.Private, // PLAYER_PET_SPELL_POWER
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+2
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+3
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+4
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+5
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+6
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+7
        UpdateFieldVisibilityFlags.Private, // PLAYER_PROFESSION_SKILL_LINE_1
        UpdateFieldVisibilityFlags.Private, // PLAYER_PROFESSION_SKILL_LINE_1+1
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_UI_HIT_MODIFIER
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_UI_SPELL_HIT_MODIFIER
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_HOME_REALM_TIME_OFFSET
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HASTE
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_RANGED_HASTE
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_PET_HASTE
        UpdateFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HASTE_REGEN
    ];

    public static readonly UpdateFieldVisibilityFlags[] SItemVisibilityFlags =
    [
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID+1
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA+1
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_TYPE
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_ENTRY
        UpdateFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_SCALE_X
        UpdateFieldVisibilityFlags.None,                                           // OBJECT_FIELD_PADDING
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_OWNER
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_OWNER+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_CONTAINED
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_CONTAINED+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_CREATOR
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_CREATOR+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_GIFTCREATOR
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_GIFTCREATOR+1
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_STACK_COUNT
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_DURATION
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_SPELL_CHARGES
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_SPELL_CHARGES+1
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_SPELL_CHARGES+2
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_SPELL_CHARGES+3
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_SPELL_CHARGES+4
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_FLAGS
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_1_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_1_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_1_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_2_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_2_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_2_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_3_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_3_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_3_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_4_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_4_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_4_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_5_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_5_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_5_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_6_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_6_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_6_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_7_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_7_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_7_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_8_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_8_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_8_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_9_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_9_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_9_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_10_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_10_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_10_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_11_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_11_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_11_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_12_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_12_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_12_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_13_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_13_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_13_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_14_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_14_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_14_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_15_1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_15_1+1
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_ENCHANTMENT_15_3
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_PROPERTY_SEED
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_RANDOM_PROPERTIES_ID
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_DURABILITY
        UpdateFieldVisibilityFlags.Owner | UpdateFieldVisibilityFlags.ItemOwner,   // ITEM_FIELD_MAXDURABILITY
        UpdateFieldVisibilityFlags.Public,                                         // ITEM_FIELD_CREATE_PLAYED_TIME
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_NUM_SLOTS
        UpdateFieldVisibilityFlags.None,                                           // CONTAINER_ALIGN_PAD
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+1
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+2
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+3
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+4
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+5
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+6
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+7
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+8
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+9
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+10
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+11
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+12
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+13
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+14
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+15
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+16
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+17
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+18
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+19
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+20
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+21
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+22
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+23
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+24
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+25
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+26
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+27
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+28
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+29
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+30
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+31
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+32
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+33
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+34
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+35
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+36
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+37
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+38
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+39
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+40
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+41
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+42
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+43
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+44
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+45
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+46
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+47
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+48
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+49
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+50
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+51
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+52
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+53
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+54
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+55
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+56
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+57
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+58
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+59
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+60
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+61
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+62
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+63
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+64
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+65
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+66
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+67
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+68
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+69
        UpdateFieldVisibilityFlags.Public,                                         // CONTAINER_FIELD_SLOT_1+70
        UpdateFieldVisibilityFlags.Public                                          // CONTAINER_FIELD_SLOT_1+71
    ];
}
