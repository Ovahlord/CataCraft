using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimReplacement.dbc")]
public sealed class AnimReplacementEntry
{
    [Index(true)]
    public uint ID;
    public int SrcAnimID;
    public int DstAnimID;
    public int ParentAnimReplacementSetID;
}
