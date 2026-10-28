using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitBoneSetAlias.dbc")]
public sealed class AnimKitBoneSetAliasEntry
{
    [Index(true)]
    public uint ID;
    public int BoneDataID;
    public int AnimKitBoneSetID;
}
