using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitBoneSetAlias.dbc")]
public sealed class AnimKitBoneSetAliasEntry
{
    [Index(true)]
    public uint ID;
    public int BoneDataID;
    public int AnimKitBoneSetID;
}
