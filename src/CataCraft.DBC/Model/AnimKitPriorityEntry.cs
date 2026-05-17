using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitPriority.dbc")]
public sealed class AnimKitPriorityEntry
{
    [Index(true)]
    public uint ID;
    public int Priority;
}
