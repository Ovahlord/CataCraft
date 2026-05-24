using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldStateUI.dbc")]
public sealed class WorldStateUIEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int AreaID;
    public int PhaseUseFlags;
    public int PhaseID;
    public int PhaseGroupID;
    public string Icon = string.Empty;
    public string String = string.Empty;
    public string Tooltip = string.Empty;
    public int StateVariable;
    public int Type;
    public string DynamicIcon = string.Empty;
    public string DynamicTooltip = string.Empty;
    public string ExtendedUI = string.Empty;
    [Cardinality(3)]
    public int[] ExtendedUIStateVariable = new int[3];
}
