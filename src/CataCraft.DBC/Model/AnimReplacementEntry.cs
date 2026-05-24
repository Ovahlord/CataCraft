using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimReplacement.dbc")]
public sealed class AnimReplacementEntry
{
    [Index(false)]
    public uint ID;
    public int SrcAnimID;
    public int DstAnimID;
    public int ParentAnimReplacementSetID;
}
