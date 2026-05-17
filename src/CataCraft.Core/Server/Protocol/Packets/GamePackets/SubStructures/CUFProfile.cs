// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public class CUFProfile
{
    public string Name { get; set; } = string.Empty;
    public ushort FrameHeight { get; set; }
    public ushort FrameWidth { get; set; }
    public byte SortBy { get; set; }
    public byte HealthText { get; set; }
    public bool KeepGroupsTogether { get; set; }
    public bool DisplayPets { get; set; }
    public bool DisplayMainTankAndAssist { get; set; }
    public bool DisplayHealPrediction { get; set; }
    public bool DisplayAggroHighlight { get; set; }
    public bool DisplayOnlyDispellableDebuffs { get; set; }
    public bool DisplayPowerBar { get; set; }
    public bool DisplayBorder { get; set; }
    public bool UseClassColors { get; set; }
    public bool HorizontalGroups { get; set; }
    public bool DisplayNonBossDebuffs { get; set; }
    public bool DynamicPosition { get; set; }
    public byte TopPoint { get; set; }
    public byte BottomPoint { get; set; }
    public byte LeftPoint { get; set; }
    public ushort TopOffset { get; set; }
    public ushort BottomOffset { get; set; }
    public ushort LeftOffset { get; set; }
    public bool Locked { get; set; }
    public bool Shown { get; set; }
    public bool AutoActivate2Players { get; set; }
    public bool AutoActivate3Players { get; set; }
    public bool AutoActivate5Players { get; set; }
    public bool AutoActivate10Players { get; set; }
    public bool AutoActivate15Players { get; set; }
    public bool AutoActivate25Players { get; set; }
    public bool AutoActivate40Players { get; set; }
    public bool AutoActivateSpec1 { get; set; }
    public bool AutoActivateSpec2 { get; set; }
    public bool AutoActivatePvP { get; set; }
    public bool AutoActivatePvE { get; set; }
}
