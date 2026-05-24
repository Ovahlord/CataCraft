// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Database.Realm.Model;
using CataCraft.DBC;
using CataCraft.DBC.Model;

namespace CataCraft.Core.Game.World.Entities.Player;

public class Player : Unit.Unit
{
    #region DataField accessors

    public byte SkinId
    {
        get => DataFields.GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 0);
        set => DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 0, value);
    }

    public byte FaceId
    {
        get => DataFields.GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 1);
        set => DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 1, value);
    }

    public byte HairStyleId
    {
        get => DataFields.GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 2);
        set => DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 2, value);
    }

    public byte HairColorId
    {
        get => DataFields.GetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 3);
        set => DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES, 0, 3, value);
    }

    public byte FacialHairStyleId
    {
        get => DataFields.GetUInt8Value(EPlayerFields.PLAYER_BYTES_2, 0, 0);
        set => DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES_2, 0, 0, value);
    }

    public UnitSex PlayerSex
    {
        get => (UnitSex)DataFields.GetUInt8Value(EPlayerFields.PLAYER_BYTES_3, 0, 0);
        set => DataFields.SetUInt8Value(EPlayerFields.PLAYER_BYTES_3, 0, 0, (byte)value);
    }

    public byte MaxLevel
    {
        get => (byte)DataFields.GetUInt32Value(EPlayerFields.PLAYER_FIELD_MAX_LEVEL, 0);
        set => DataFields.SetUInt32Value(EPlayerFields.PLAYER_FIELD_MAX_LEVEL, 0, value);
    }

    #endregion // DataField accessors

    public Player(WowGuid guid) : base(guid)
    {
    }

    public static Player? CreatePlayerFromData(Character characterData)
    {
        if (characterData.Stats == null)
            return null;

        Player player = new(new WowGuid(WowGuidType.Player, (uint)characterData.Id))
        {
            Sex = (UnitSex)characterData.SexId,
            PlayerSex = (UnitSex)characterData.SexId,
            FaceId = characterData.FaceId,
            SkinId = characterData.SkinId,
            HairStyleId = characterData.HairStyleId,
            HairColorId = characterData.HairColorId,
            FacialHairStyleId = characterData.FacialHairStyleId,
            Level = characterData.Stats.ExperienceLevel,
            MaxLevel = 85,
            Race = (ChrRace)characterData.RaceId,
            Class = (UnitClass)characterData.ClassId,

            Flags = UnitFlags.PlayerControlled,
            Flags2 = UnitFlags2.RegeneratePower,

            BaseHealth = 100,
            BaseMana = 0,
            MaxHealth = 100,
            Health = 100,

            BoundingRadius = 1f,
            CombatReach = 1f,
            HoverHeight = 1f,
        };

        if (DBCManager.SChrRacesStore.TryGetValue(characterData.RaceId, out ChrRacesEntry? race))
        {
            player.FactionTemplateId = (uint)race.FactionID;
            if (player.Sex == UnitSex.Male)
            {
                player.DisplayId = (uint)race.MaleDisplayID;
                player.NativeDisplayId = (uint)race.MaleDisplayID;
            }
            else
            {
                player.DisplayId = (uint)race.FemaleDisplayID;
                player.NativeDisplayId = (uint)race.FemaleDisplayID;
            }
        }

        return player;
    }
}
