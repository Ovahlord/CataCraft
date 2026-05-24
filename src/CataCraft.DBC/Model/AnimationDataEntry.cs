using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimationData.dbc")]
public sealed class AnimationDataEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
    public int Fallback;
    public int BehaviorID;
    public int BehaviorTier;
}
