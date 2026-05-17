using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MovieFileData.dbc")]
public sealed class MovieFileDataEntry
{
    [Index(true)]
    public uint FileDataID;
    public int Resolution;
}
