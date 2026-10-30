// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Unit;

public class Power
{
    private readonly UnitBase _owner;
    private readonly int  _powerIndex;

    public PowerType PowerType { get; private set; }

    public bool RegenerationAffectedByHaste
    {
        get
        {
            switch (PowerType)
            {
                case PowerType.Energy:
                case PowerType.Focus:
                case PowerType.Runes:
                    return true;
                default:
                    return false;
            }
        }
    }

    public bool SetToMaxOnInitialLogin
    {
        get
        {
            switch (PowerType)
            {
                case PowerType.Mana:
                case PowerType.Rage:
                case PowerType.Focus:
                case PowerType.Energy:
                case PowerType.Runes:
                    return true;
                default:
                    return false;
            }
        }
    }

    public Power(UnitBase owner, int powerIndex, PowerType powerType)
    {
        _owner = owner;
        _powerIndex =  powerIndex;
        PowerType = powerType;

        if (powerType == PowerType.Mana)
            UpdateBaseMana();

        UpdateMinMaxPower();
        UpdateRegeneration();
    }

    public int MinValue { get; private set; } = 0;

    public int MaxValue
    {
        get => _owner.GetInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER1, _powerIndex);
        set => _owner.SetInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER1, _powerIndex, Math.Max(value, MinValue));
    }

    public int Value
    {
        get => _owner.GetInt32Value(EUnitFields.UNIT_FIELD_POWER1, _powerIndex);
        set => _owner.SetInt32Value(EUnitFields.UNIT_FIELD_POWER1, _powerIndex, Math.Clamp(value, MinValue, MaxValue));
    }

    public int RegenFlatModifier
    {
        get => _owner.GetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER, _powerIndex);
        set => _owner.SetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER, _powerIndex, value);
    }

    public int RegenInterruptedFlatModifier
    {
        get => _owner.GetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER, _powerIndex);
        set => _owner.SetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER, _powerIndex, value);
    }

    public float HasteRegenModifier
    {
        get => _owner.GetFloatValue(EPlayerFields.PLAYER_FIELD_MOD_HASTE_REGEN, _powerIndex);
        set => _owner.SetFloatValue(EPlayerFields.PLAYER_FIELD_MOD_HASTE_REGEN, _powerIndex, value);
    }

    public void UpdateMinMaxPower()
    {
        // Values extracted from the Cataclysm Classic PowerTypes.db2 records
        switch (PowerType)
        {
            case PowerType.Mana:
                UpdateBaseMana();
                MinValue = 0;
                MaxValue = _owner.BaseMana + CalculateManaBonusFromIntellect();
                break;
            case PowerType.Rage:
                MinValue = 0;
                MaxValue = 1000;
                break;
            case PowerType.Focus:
            case PowerType.Energy:
                MinValue = 0;
                MaxValue = 100;
                break;
            case PowerType.Unused:
                MinValue = 0;
                MaxValue = 0;
                break;
            case PowerType.Runes:
                MinValue = 0;
                MaxValue = 0;
                break;
            case PowerType.RunicPower:
                MinValue = 0;
                MaxValue = 1000;
                break;
            case PowerType.SoulShards:
                MinValue = 0;
                MaxValue = 3;
                break;
            case PowerType.LunarPower:
                MinValue = -100;
                MaxValue = 100;
                break;
            case PowerType.HolyPower:
                MinValue = 0;
                MaxValue = 3;
                break;
            case PowerType.Alternate:
                MinValue = 0;
                MaxValue = 100;
                break;
            default:
                MinValue = 0;
                MaxValue = 0;
                break;
        }
    }

    private void UpdateBaseMana()
    {
        int key = (int)_owner.Class * 100 + _owner.Level - 1;
        if (DBCManager.SgtOCTBaseMPByClassStore.TryGetValue(key, out gtOCTBaseMPByClassEntry? entry))
            _owner.SetInt32Value(EUnitFields.UNIT_FIELD_BASE_MANA, 0, (int)entry.Data);
    }

    private int CalculateManaBonusFromIntellect()
    {
        int intellect = _owner.Stats[UnitStats.Intellect].Value;
        int baseInt = Math.Min(20, intellect);
        int moreInt = intellect - baseInt;

        return baseInt + moreInt * 15;
    }

    public void UpdateRegeneration()
    {

    }

    public static bool IsUsedByNpcs(PowerType powerType)
    {
        switch (powerType)
        {
            case PowerType.Mana:
            case PowerType.Energy:
            case PowerType.Focus:
            case PowerType.Alternate:
                return true;
            default:
                return false;
        }
    }
}
