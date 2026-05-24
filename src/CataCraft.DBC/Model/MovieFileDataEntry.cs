using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MovieFileData.dbc")]
public sealed class MovieFileDataEntry
{
    [Index(false)]
    public uint FileDataID;
    public int Resolution;
}
