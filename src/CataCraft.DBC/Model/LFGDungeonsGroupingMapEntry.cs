using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LFGDungeonsGroupingmap.dbc")]
public sealed class LFGDungeonsGroupingMapEntry
{
    [Index(true)]
    public uint ID;
    public int LfgDungeonsID;
    public int RandomLfgDungeonsID;
    public int GroupID;
}
