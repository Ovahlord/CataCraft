using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimReplacementSet.dbc")]
public sealed class AnimReplacementSetEntry
{
    [Index(true)]
    public uint ID;
    public int ExecOrder;
}
