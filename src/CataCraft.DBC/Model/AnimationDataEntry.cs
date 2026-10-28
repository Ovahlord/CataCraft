using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimationData.dbc")]
public sealed class AnimationDataEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
    public int Fallback;
    public int BehaviorID;
    public int BehaviorTier;
}
