using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FileData.dbc")]
public sealed class FileDataEntry
{
    [Index(false)]
    public uint ID;
    public string Filename = string.Empty;
    public string Filepath = string.Empty;
}
