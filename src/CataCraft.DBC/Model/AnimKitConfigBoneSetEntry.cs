using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitConfigBoneSet.dbc")]
public sealed class AnimKitConfigBoneSetEntry
{
    [Index(false)]
    public uint ID;
    public int ParentAnimKitConfigID;
    public int AnimKitBoneSetID;
    public int AnimKitPriorityID;
}
