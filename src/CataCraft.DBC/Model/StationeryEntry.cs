using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Stationery.dbc")]
public sealed class StationeryEntry
{
    [Index(true)]
    public uint ID;
    public int ItemID;
    public string Texture = string.Empty;
    public int Flags;
}
