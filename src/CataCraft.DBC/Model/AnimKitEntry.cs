using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKit.dbc")]
public sealed class AnimKitEntry
{
    [Index(false)]
    public uint ID;
    public int OneShotDuration;
    public int OneShotStopAnimKitID;
}
