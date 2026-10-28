using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MovieFileData.dbc")]
public sealed class MovieFileDataEntry
{
    [Index(true)]
    public uint FileDataID;
    public int Resolution;
}
