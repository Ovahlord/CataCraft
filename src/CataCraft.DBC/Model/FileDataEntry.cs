using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FileData.dbc")]
public sealed class FileDataEntry
{
    [Index(true)]
    public uint ID;
    public string Filename = string.Empty;
    public string Filepath = string.Empty;
}
