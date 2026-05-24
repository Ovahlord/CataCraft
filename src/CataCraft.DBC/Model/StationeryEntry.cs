using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Stationery.dbc")]
public sealed class StationeryEntry
{
    [Index(false)]
    public uint ID;
    public int ItemID;
    public string Texture = string.Empty;
    public int Flags;
}
