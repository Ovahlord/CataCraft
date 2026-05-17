// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.World.Entities.Object.DataFields;

public static class ObjectDataFieldConstants
{
    public static readonly DataFieldVisibilityFlags[] SUnitVisibilityFlags =
    [
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID+1
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA+1
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_TYPE
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_ENTRY
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_SCALE_X
        DataFieldVisibilityFlags.None,                                           // OBJECT_FIELD_PADDING
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON+1
        DataFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER
        DataFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_CHANNEL_SPELL
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_0
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HEALTH
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER3
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER4
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER5
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXHEALTH
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER3
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER4
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+4
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_LEVEL
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FACTIONTEMPLATE
        DataFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID
        DataFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS_2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_AURASTATE
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME+1
        DataFieldVisibilityFlags.Private,                                        // UNIT_FIELD_RANGEDATTACKTIME
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BOUNDINGRADIUS
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_COMBATREACH
        DataFieldVisibilityFlags.Dynamic,                                        // UNIT_FIELD_DISPLAYID
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_NATIVEDISPLAYID
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MOUNTDISPLAYID
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINOFFHANDDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXOFFHANDDAMAGE
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PETNUMBER
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PET_NAME_TIMESTAMP
        DataFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETEXPERIENCE
        DataFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETNEXTLEVELEXP
        DataFieldVisibilityFlags.Dynamic,                                        // UNIT_DYNAMIC_FLAGS
        DataFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_SPEED
        DataFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_HASTE
        DataFieldVisibilityFlags.Public,                                         // UNIT_CREATED_BY_SPELL
        DataFieldVisibilityFlags.Dynamic,                                        // UNIT_NPC_FLAGS
        DataFieldVisibilityFlags.Public,                                         // UNIT_NPC_EMOTESTATE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT0
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT0
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT0
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+6
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASE_MANA
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_BASE_HEALTH
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_POS
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_NEG
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MULTIPLIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MINRANGEDDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXRANGEDDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXHEALTHMODIFIER
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HOVERHEIGHT
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXITEMLEVEL
        DataFieldVisibilityFlags.None                                            // UNIT_FIELD_PADDING
    ];

        public static readonly DataFieldVisibilityFlags[] SPlayerVisibilityFlags =
    [
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_GUID+1
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_DATA+1
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_TYPE
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_ENTRY
        DataFieldVisibilityFlags.Public,                                         // OBJECT_FIELD_SCALE_X
        DataFieldVisibilityFlags.None,                                           // OBJECT_FIELD_PADDING
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARM+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMON+1
        DataFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER
        DataFieldVisibilityFlags.Private,                                        // UNIT_FIELD_CRITTER+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHARMEDBY+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_SUMMONEDBY+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CREATEDBY+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_TARGET+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_CHANNEL_OBJECT+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_CHANNEL_SPELL
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_0
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HEALTH
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER3
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER4
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_POWER5
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXHEALTH
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER3
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER4
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXPOWER5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.UnitAll,     // UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER+4
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_LEVEL
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FACTIONTEMPLATE
        DataFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID
        DataFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+1
        DataFieldVisibilityFlags.Public,                                         // UNIT_VIRTUAL_ITEM_SLOT_ID+2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_FLAGS_2
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_AURASTATE
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASEATTACKTIME+1
        DataFieldVisibilityFlags.Private,                                        // UNIT_FIELD_RANGEDATTACKTIME
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BOUNDINGRADIUS
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_COMBATREACH
        DataFieldVisibilityFlags.Dynamic,                                        // UNIT_FIELD_DISPLAYID
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_NATIVEDISPLAYID
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MOUNTDISPLAYID
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MINOFFHANDDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_MAXOFFHANDDAMAGE
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_1
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PETNUMBER
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_PET_NAME_TIMESTAMP
        DataFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETEXPERIENCE
        DataFieldVisibilityFlags.Owner,                                          // UNIT_FIELD_PETNEXTLEVELEXP
        DataFieldVisibilityFlags.Dynamic,                                        // UNIT_DYNAMIC_FLAGS
        DataFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_SPEED
        DataFieldVisibilityFlags.Public,                                         // UNIT_MOD_CAST_HASTE
        DataFieldVisibilityFlags.Public,                                         // UNIT_CREATED_BY_SPELL
        DataFieldVisibilityFlags.Dynamic,                                        // UNIT_NPC_FLAGS
        DataFieldVisibilityFlags.Public,                                         // UNIT_NPC_EMOTESTATE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT0
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_STAT4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT0
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POSSTAT4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT0
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_NEGSTAT4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner | DataFieldVisibilityFlags.SpecialInfo, // UNIT_FIELD_RESISTANCES+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE+6
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BASE_MANA
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_BASE_HEALTH
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_BYTES_2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_POS
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MOD_NEG
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_ATTACK_POWER_MULTIPLIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MINRANGEDDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXRANGEDDAMAGE
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MODIFIER+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+1
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+2
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+3
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+4
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+5
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_POWER_COST_MULTIPLIER+6
        DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.Owner,                        // UNIT_FIELD_MAXHEALTHMODIFIER
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_HOVERHEIGHT
        DataFieldVisibilityFlags.Public,                                         // UNIT_FIELD_MAXITEMLEVEL
        DataFieldVisibilityFlags.None,                                            // UNIT_FIELD_PADDING
        DataFieldVisibilityFlags.Public, // PLAYER_DUEL_ARBITER
        DataFieldVisibilityFlags.Public, // PLAYER_DUEL_ARBITER+1
        DataFieldVisibilityFlags.Public, // PLAYER_FLAGS
        DataFieldVisibilityFlags.Public, // PLAYER_GUILDRANK
        DataFieldVisibilityFlags.Public, // PLAYER_GUILDDELETE_DATE
        DataFieldVisibilityFlags.Public, // PLAYER_GUILDLEVEL
        DataFieldVisibilityFlags.Public, // PLAYER_BYTES
        DataFieldVisibilityFlags.Public, // PLAYER_BYTES_2
        DataFieldVisibilityFlags.Public, // PLAYER_BYTES_3
        DataFieldVisibilityFlags.Public, // PLAYER_DUEL_TEAM
        DataFieldVisibilityFlags.Public, // PLAYER_GUILD_TIMESTAMP
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_1_4
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_2_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_3_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_4_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_5_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_6_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_7_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_8_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_9_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_10_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_11_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_12_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_13_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_14_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_15_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_16_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_17_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_18_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_19_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_20_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_21_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_22_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_23_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_24_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_25_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_26_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_27_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_28_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_29_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_30_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_31_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_32_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_33_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_34_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_35_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_36_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_37_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_38_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_39_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_40_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_41_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_42_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_43_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_44_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_45_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_46_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_47_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_48_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_49_5
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_2
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_3
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_3+1
        DataFieldVisibilityFlags.PartyMember, // PLAYER_QUEST_LOG_50_5
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_1_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_1_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_2_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_2_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_3_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_3_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_4_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_4_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_5_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_5_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_6_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_6_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_7_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_7_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_8_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_8_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_9_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_9_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_10_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_10_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_11_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_11_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_12_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_12_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_13_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_13_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_14_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_14_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_15_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_15_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_16_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_16_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_17_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_17_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_18_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_18_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_19_ENTRYID
        DataFieldVisibilityFlags.Public, // PLAYER_VISIBLE_ITEM_19_ENCHANTMENT
        DataFieldVisibilityFlags.Public, // PLAYER_CHOSEN_TITLE
        DataFieldVisibilityFlags.Public, // PLAYER_FAKE_INEBRIATION
        DataFieldVisibilityFlags.None, // PLAYER_FIELD_PAD_0
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+14
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+15
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+16
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+17
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+18
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+19
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+20
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+21
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+22
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+23
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+24
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+25
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+26
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+27
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+28
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+29
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+30
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+31
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+32
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+33
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+34
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+35
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+36
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+37
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+38
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+39
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+40
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+41
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+42
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+43
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+44
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_INV_SLOT_HEAD+45
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+14
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+15
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+16
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+17
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+18
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+19
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+20
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+21
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+22
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+23
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+24
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+25
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+26
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+27
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+28
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+29
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+30
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PACK_SLOT_1+31
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+14
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+15
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+16
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+17
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+18
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+19
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+20
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+21
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+22
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+23
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+24
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+25
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+26
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+27
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+28
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+29
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+30
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+31
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+32
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+33
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+34
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+35
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+36
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+37
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+38
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+39
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+40
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+41
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+42
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+43
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+44
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+45
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+46
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+47
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+48
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+49
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+50
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+51
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+52
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+53
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+54
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANK_SLOT_1+55
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BANKBAG_SLOT_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+14
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+15
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+16
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+17
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+18
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+19
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+20
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+21
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+22
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_VENDORBUYBACK_SLOT_1+23
        DataFieldVisibilityFlags.Private, // PLAYER_FARSIGHT
        DataFieldVisibilityFlags.Private, // PLAYER_FARSIGHT+1
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES+1
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES1
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES1+1
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES2
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES2+1
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES3
        DataFieldVisibilityFlags.Private, // PLAYER__FIELD_KNOWN_TITLES3+1
        DataFieldVisibilityFlags.Private, // PLAYER_XP
        DataFieldVisibilityFlags.Private, // PLAYER_NEXT_LEVEL_XP
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+1
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+2
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+3
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+4
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+5
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+6
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+7
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+8
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+9
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+10
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+11
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+12
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+13
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+14
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+15
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+16
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+17
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+18
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+19
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+20
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+21
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+22
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+23
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+24
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+25
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+26
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+27
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+28
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+29
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+30
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+31
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+32
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+33
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+34
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+35
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+36
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+37
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+38
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+39
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+40
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+41
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+42
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+43
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+44
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+45
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+46
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+47
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+48
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+49
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+50
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+51
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+52
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+53
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+54
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+55
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+56
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+57
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+58
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+59
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+60
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+61
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+62
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_LINEID_0+63
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+1
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+2
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+3
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+4
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+5
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+6
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+7
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+8
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+9
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+10
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+11
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+12
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+13
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+14
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+15
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+16
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+17
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+18
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+19
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+20
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+21
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+22
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+23
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+24
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+25
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+26
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+27
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+28
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+29
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+30
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+31
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+32
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+33
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+34
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+35
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+36
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+37
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+38
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+39
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+40
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+41
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+42
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+43
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+44
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+45
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+46
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+47
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+48
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+49
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+50
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+51
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+52
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+53
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+54
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+55
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+56
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+57
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+58
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+59
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+60
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+61
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+62
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_STEP_0+63
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+1
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+2
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+3
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+4
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+5
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+6
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+7
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+8
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+9
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+10
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+11
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+12
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+13
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+14
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+15
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+16
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+17
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+18
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+19
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+20
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+21
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+22
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+23
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+24
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+25
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+26
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+27
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+28
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+29
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+30
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+31
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+32
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+33
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+34
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+35
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+36
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+37
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+38
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+39
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+40
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+41
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+42
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+43
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+44
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+45
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+46
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+47
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+48
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+49
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+50
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+51
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+52
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+53
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+54
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+55
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+56
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+57
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+58
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+59
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+60
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+61
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+62
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_RANK_0+63
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+1
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+2
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+3
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+4
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+5
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+6
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+7
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+8
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+9
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+10
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+11
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+12
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+13
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+14
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+15
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+16
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+17
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+18
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+19
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+20
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+21
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+22
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+23
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+24
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+25
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+26
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+27
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+28
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+29
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+30
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+31
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+32
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+33
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+34
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+35
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+36
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+37
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+38
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+39
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+40
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+41
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+42
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+43
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+44
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+45
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+46
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+47
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+48
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+49
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+50
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+51
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+52
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+53
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+54
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+55
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+56
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+57
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+58
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+59
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+60
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+61
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+62
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MAX_RANK_0+63
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+1
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+2
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+3
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+4
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+5
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+6
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+7
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+8
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+9
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+10
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+11
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+12
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+13
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+14
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+15
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+16
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+17
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+18
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+19
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+20
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+21
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+22
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+23
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+24
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+25
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+26
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+27
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+28
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+29
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+30
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+31
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+32
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+33
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+34
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+35
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+36
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+37
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+38
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+39
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+40
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+41
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+42
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+43
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+44
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+45
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+46
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+47
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+48
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+49
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+50
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+51
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+52
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+53
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+54
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+55
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+56
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+57
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+58
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+59
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+60
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+61
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+62
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_MODIFIER_0+63
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+1
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+2
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+3
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+4
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+5
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+6
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+7
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+8
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+9
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+10
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+11
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+12
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+13
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+14
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+15
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+16
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+17
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+18
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+19
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+20
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+21
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+22
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+23
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+24
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+25
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+26
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+27
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+28
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+29
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+30
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+31
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+32
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+33
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+34
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+35
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+36
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+37
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+38
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+39
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+40
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+41
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+42
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+43
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+44
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+45
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+46
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+47
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+48
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+49
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+50
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+51
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+52
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+53
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+54
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+55
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+56
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+57
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+58
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+59
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+60
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+61
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+62
        DataFieldVisibilityFlags.Private, // PLAYER_SKILL_TALENT_0+63
        DataFieldVisibilityFlags.Private, // PLAYER_CHARACTER_POINTS
        DataFieldVisibilityFlags.Private, // PLAYER_TRACK_CREATURES
        DataFieldVisibilityFlags.Private, // PLAYER_TRACK_RESOURCES
        DataFieldVisibilityFlags.Private, // PLAYER_EXPERTISE
        DataFieldVisibilityFlags.Private, // PLAYER_OFFHAND_EXPERTISE
        DataFieldVisibilityFlags.Private, // PLAYER_BLOCK_PERCENTAGE
        DataFieldVisibilityFlags.Private, // PLAYER_DODGE_PERCENTAGE
        DataFieldVisibilityFlags.Private, // PLAYER_PARRY_PERCENTAGE
        DataFieldVisibilityFlags.Private, // PLAYER_CRIT_PERCENTAGE
        DataFieldVisibilityFlags.Private, // PLAYER_RANGED_CRIT_PERCENTAGE
        DataFieldVisibilityFlags.Private, // PLAYER_OFFHAND_CRIT_PERCENTAGE
        DataFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1
        DataFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+1
        DataFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+2
        DataFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+3
        DataFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+4
        DataFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+5
        DataFieldVisibilityFlags.Private, // PLAYER_SPELL_CRIT_PERCENTAGE1+6
        DataFieldVisibilityFlags.Private, // PLAYER_SHIELD_BLOCK
        DataFieldVisibilityFlags.Private, // PLAYER_SHIELD_BLOCK_CRIT_PERCENTAGE
        DataFieldVisibilityFlags.Private, // PLAYER_MASTERY
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+14
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+15
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+16
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+17
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+18
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+19
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+20
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+21
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+22
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+23
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+24
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+25
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+26
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+27
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+28
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+29
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+30
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+31
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+32
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+33
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+34
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+35
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+36
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+37
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+38
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+39
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+40
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+41
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+42
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+43
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+44
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+45
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+46
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+47
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+48
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+49
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+50
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+51
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+52
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+53
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+54
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+55
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+56
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+57
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+58
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+59
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+60
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+61
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+62
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+63
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+64
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+65
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+66
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+67
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+68
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+69
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+70
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+71
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+72
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+73
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+74
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+75
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+76
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+77
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+78
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+79
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+80
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+81
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+82
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+83
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+84
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+85
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+86
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+87
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+88
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+89
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+90
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+91
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+92
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+93
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+94
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+95
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+96
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+97
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+98
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+99
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+100
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+101
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+102
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+103
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+104
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+105
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+106
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+107
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+108
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+109
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+110
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+111
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+112
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+113
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+114
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+115
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+116
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+117
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+118
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+119
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+120
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+121
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+122
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+123
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+124
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+125
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+126
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+127
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+128
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+129
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+130
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+131
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+132
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+133
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+134
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+135
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+136
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+137
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+138
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+139
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+140
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+141
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+142
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+143
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+144
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+145
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+146
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+147
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+148
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+149
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+150
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+151
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+152
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+153
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+154
        DataFieldVisibilityFlags.Private, // PLAYER_EXPLORED_ZONES_1+155
        DataFieldVisibilityFlags.Private, // PLAYER_REST_STATE_EXPERIENCE
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COINAGE
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COINAGE+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_POS+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_NEG+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_DAMAGE_DONE_PCT+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HEALING_DONE_POS
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HEALING_PCT
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HEALING_DONE_PCT
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_WEAPON_DMG_MULTIPLIERS
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_WEAPON_DMG_MULTIPLIERS+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_WEAPON_DMG_MULTIPLIERS+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_SPELL_POWER_PCT
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_OVERRIDE_SPELL_POWER_BY_AP_PCT
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_TARGET_RESISTANCE
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BYTES
        DataFieldVisibilityFlags.Private, // PLAYER_SELF_RES_SPELL
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_PVP_MEDALS
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_PRICE_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BUYBACK_TIMESTAMP_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_KILLS
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_LIFETIME_HONORBALE_KILLS
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BYTES2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_WATCHED_FACTION_INDEX
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+14
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+15
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+16
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+17
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+18
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+19
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+20
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+21
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+22
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+23
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+24
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_COMBAT_RATING_1+25
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+14
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+15
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+16
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+17
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+18
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+19
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_ARENA_TEAM_INFO_1_1+20
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_BATTLEGROUND_RATING
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MAX_LEVEL
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+9
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+10
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+11
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+12
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+13
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+14
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+15
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+16
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+17
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+18
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+19
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+20
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+21
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+22
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+23
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_DAILY_QUESTS_1+24
        DataFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1
        DataFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_RUNE_REGEN_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_NO_REAGENT_COST_1
        DataFieldVisibilityFlags.Private, // PLAYER_NO_REAGENT_COST_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_NO_REAGENT_COST_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPH_SLOTS_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_GLYPHS_1+8
        DataFieldVisibilityFlags.Private, // PLAYER_GLYPHS_ENABLED
        DataFieldVisibilityFlags.Private, // PLAYER_PET_SPELL_POWER
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESEARCHING_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+2
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+3
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+4
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+5
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+6
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_RESERACH_SITE_1+7
        DataFieldVisibilityFlags.Private, // PLAYER_PROFESSION_SKILL_LINE_1
        DataFieldVisibilityFlags.Private, // PLAYER_PROFESSION_SKILL_LINE_1+1
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_UI_HIT_MODIFIER
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_UI_SPELL_HIT_MODIFIER
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_HOME_REALM_TIME_OFFSET
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HASTE
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_RANGED_HASTE
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_PET_HASTE
        DataFieldVisibilityFlags.Private, // PLAYER_FIELD_MOD_HASTE_REGEN
    ];
}
