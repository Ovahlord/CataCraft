using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ZoneLight.dbc")]
public sealed class ZoneLightEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int MapID;
    public int LightID;
}
