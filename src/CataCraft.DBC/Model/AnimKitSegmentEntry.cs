using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitSegment.dbc")]
public sealed class AnimKitSegmentEntry
{
    [Index(false)]
    public uint ID;
    public int ParentAnimKitID;
    public int AnimID;
    public int AnimStartTime;
    public int AnimKitConfigID;
    public int StartCondition;
    public int StartConditionParam;
    public int StartConditionDelay;
    public int EndCondition;
    public int EndConditionParam;
    public int EndConditionDelay;
    public float Speed;
    public int SegmentFlags;
    public int ForcedVariation;
    public int OverrideConfigFlags;
    public int LoopToSegmentIndex;
}
