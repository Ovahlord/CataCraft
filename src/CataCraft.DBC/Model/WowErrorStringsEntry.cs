using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WowError_Strings.dbc")]
public sealed class WowErrorStringsEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public string Description = string.Empty;
}
