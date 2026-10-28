using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitConfigBoneSet.dbc")]
public sealed class AnimKitConfigBoneSetEntry
{
    [Index(true)]
    public uint ID;
    public int ParentAnimKitConfigID;
    public int AnimKitBoneSetID;
    public int AnimKitPriorityID;
}
