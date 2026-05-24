using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Achievement.dbc")]
public sealed class AchievementEntry
{
    [Index(false)]
    public uint ID;
    public int Faction;
    public int InstanceID;
    public int Supercedes;
    public string Title = string.Empty;
    public string Description = string.Empty;
    public int Category;
    public int Points;
    public int UiOrder;
    public int Flags;
    public int IconID;
    public string Reward = string.Empty;
    public int MinimumCriteria;
    public int SharesCriteria;
}
