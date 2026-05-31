// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.Entities.Unit;

public class Power
{
    private readonly Unit _owner;
    private readonly int  _powerIndex;

    public UnitPowerType PowerType
    {
        get;
        private set
        {
            field = value;
            UpdateBaseMinMaxPower();
            UpdateRegeneration();
        }
    }

    public Power(Unit owner, int powerIndex, UnitPowerType powerType)
    {
        _owner = owner;
        _powerIndex =  powerIndex;
        PowerType = powerType;
    }

    public int MinValue { get; private set; } = 0;

    public int MaxValue
    {
        get => _owner.DataFields.GetInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER1, _powerIndex);
        set => _owner.DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_MAXPOWER1, _powerIndex, value);
    }

    public int Value
    {
        get => _owner.DataFields.GetInt32Value(EUnitFields.UNIT_FIELD_POWER1, _powerIndex);
        set => _owner.DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_POWER1, _powerIndex, value);
    }

    public int RegenFlatModifier
    {
        get => _owner.DataFields.GetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER, _powerIndex);
        set => _owner.DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER, _powerIndex, value);
    }

    public int RegenInterruptedFlatModifier
    {
        get => _owner.DataFields.GetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER, _powerIndex);
        set => _owner.DataFields.SetInt32Value(EUnitFields.UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER, _powerIndex, value);
    }

    private void UpdateBaseMinMaxPower()
    {
        switch (PowerType)
        {
            case UnitPowerType.Mana:
                MinValue = 0;
                MaxValue = 0;
                break;
            case UnitPowerType.Rage:
                MinValue = 0;
                MaxValue = 1000;
                break;
            case UnitPowerType.Focus:
            case UnitPowerType.Energy:
                MinValue = 0;
                MaxValue = 100;
                break;
            case UnitPowerType.Unused:
                MinValue = 0;
                MaxValue = 0;
                break;
            case UnitPowerType.Runes:
                MinValue = 0;
                MaxValue = 0;
                break;
            case UnitPowerType.RunicPower:
                MinValue = 0;
                MaxValue = 1000;
                break;
            case UnitPowerType.SoulShards:
                MinValue = 0;
                MaxValue = 3;
                break;
            case UnitPowerType.Balance:
                MinValue = -100;
                MaxValue = 100;
                break;
            case UnitPowerType.HolyPower:
                MinValue = 0;
                MaxValue = 3;
                break;
            case UnitPowerType.AlternatePower:
                MinValue = 0;
                MaxValue = 100;
                break;
            default:
                MinValue = 0;
                MaxValue = 0;
                break;
        }
    }

    public void UpdateRegeneration()
    {

    }
}
