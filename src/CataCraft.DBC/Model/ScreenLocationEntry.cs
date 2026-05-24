using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ScreenLocation.dbc")]
public sealed class ScreenLocationEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
