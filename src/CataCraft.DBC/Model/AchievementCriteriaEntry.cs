using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Achievement_Criteria.dbc")]
public sealed class AchievementCriteriaEntry
{
    [Index(false)]
    public uint ID;
    public int AchievementID;
    public int Type;
    public int AssetID;
    public long Quantity;
    public int StartEvent;
    public int StartAsset;
    public int FailEvent;
    public int FailAsset;
    public string Description = string.Empty;
    public int Flags;
    public int TimerStartEvent;
    public int TimerAssetID;
    public int TimerTime;
    public int UiOrder;
    public int WorldStateID;
    public int RequiredWorldStateStatus;
    [Cardinality(3)]
    public int[] AdditionalConditionType = new int[3];
    [Cardinality(3)]
    public int[] AdditionalConditionValue = new int[3];
}
