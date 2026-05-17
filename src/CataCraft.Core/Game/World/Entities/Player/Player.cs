// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;

namespace CataCraft.Core.Game.World.Entities.Player;

public class Player : Unit.Unit
{
    public Player(WowGuid guid) : base(guid)
    {
        MaxHealth = 100;
        Health = 100;
        BaseHealth = 100;
        BaseMana = 0;
        HoverHeight = 1f;

        DataFields.SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 0, 4);
        DataFields.SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 1, 11);
        DataFields.SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 2, 0);
        DataFields.SetUInt8Value(EUnitFields.UNIT_FIELD_BYTES_0, 0, 3, 0);

        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_POWER1, 0, 3844);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_POWER3, 0, 100);

        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER1, 0, 3844);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER2, 0, 1000);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER3, 0, 100);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER4, 0, 100);

        SetBaseAttackTime(2000);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, 0, 4);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_LEVEL, 0, 1);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_DISPLAYID, 0, 53);
        DataFields.SetUInt32Value(EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, 0, 53);
        DataFields.SetFloatValue(EUnitFields.UNIT_FIELD_COMBATREACH, 0, 1.5f);
        DataFields.SetFloatValue(EUnitFields.UNIT_FIELD_BOUNDINGRADIUS, 0, 0.356f);
        DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_STAT4, 0, 32);
        DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_FLAGS, 0, 0x8);
        //DataFields.SetInt32Value(EPlayerFields.PLAYER_FLAGS, 0, 0);

        DataFields.SetInt32Value(EPlayerFields.PLAYER_XP, 0, 123);
        DataFields.SetInt32Value(EPlayerFields.PLAYER_NEXT_LEVEL_XP, 0, 100000);

        MovementStatus.MoveTime = (uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        MovementStatus.MovementFlags0 = MovementFlags0.CanFly | MovementFlags0.Flying;
        MovementStatus.Facing = 0.1f;

        DataFields.SetUInt8Value(EPlayerFields.PLAYER_FIELD_BYTES, 0, 0, 8);
        DataFields.SetUInt8Value(EPlayerFields.PLAYER_FIELD_BYTES, 0, 1, 1);

        DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 0, 3);
        DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 1, 5);
        DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 2, 0);
        DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 3, 1);

        DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES_2, 0, 0, 9);
        DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES_2, 0, 3, 1);

        DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES_3, 0, 0, 1);

        DataFields.SetUInt32Value(EPlayerFields.PLAYER_FIELD_MAX_LEVEL, 0, 85);
        DataFields.SetUInt32Value(EPlayerFields.PLAYER_CHARACTER_POINTS, 0, 1);
    }
}
