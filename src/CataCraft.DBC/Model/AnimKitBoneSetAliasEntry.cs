using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitBoneSetAlias.dbc")]
public sealed class AnimKitBoneSetAliasEntry
{
    [Index(false)]
    public uint ID;
    public int BoneDataID;
    public int AnimKitBoneSetID;
}
