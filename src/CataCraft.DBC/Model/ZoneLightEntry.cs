using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ZoneLight.dbc")]
public sealed class ZoneLightEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int MapID;
    public int LightID;
}
