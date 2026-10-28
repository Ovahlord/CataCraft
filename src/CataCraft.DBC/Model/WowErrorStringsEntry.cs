using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WowError_Strings.dbc")]
public sealed class WowErrorStringsEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public string Description = string.Empty;
}
