using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Startup_Strings.dbc")]
public sealed class StartupStringsEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public string Message = string.Empty;
}
