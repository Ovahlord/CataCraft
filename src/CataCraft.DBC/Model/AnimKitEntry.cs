using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKit.dbc")]
public sealed class AnimKitEntry
{
    [Index(true)]
    public uint ID;
    public int OneShotDuration;
    public int OneShotStopAnimKitID;
}
