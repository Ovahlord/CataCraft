using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitBoneSet.dbc")]
public sealed class AnimKitBoneSetEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int BoneDataID;
    public int ParentAnimKitBoneSetID;
    public int ExtraBoneCount;
    public int AltAnimKitBoneSetID;
}
