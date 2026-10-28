using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ZoneIntroMusicTable.dbc")]
public sealed class ZoneIntroMusicTableEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int SoundID;
    public int Priority;
    public int MinDelayMinutes;
}
