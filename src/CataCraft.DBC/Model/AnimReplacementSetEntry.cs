using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimReplacementSet.dbc")]
public sealed class AnimReplacementSetEntry
{
    [Index(false)]
    public uint ID;
    public int ExecOrder;
}
