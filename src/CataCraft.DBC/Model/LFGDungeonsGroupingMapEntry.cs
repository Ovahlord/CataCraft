using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LFGDungeonsGroupingmap.dbc")]
public sealed class LFGDungeonsGroupingMapEntry
{
    [Index(false)]
    public uint ID;
    public int LfgDungeonsID;
    public int RandomLfgDungeonsID;
    public int GroupID;
}
