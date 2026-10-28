using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ScreenLocation.dbc")]
public sealed class ScreenLocationEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
