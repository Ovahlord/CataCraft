using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Startup_Strings.dbc")]
public sealed class StartupStringsEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public string Message = string.Empty;
}
