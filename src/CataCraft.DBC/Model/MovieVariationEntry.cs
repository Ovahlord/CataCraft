using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MovieVariation.dbc")]
public sealed class MovieVariationEntry
{
    [Index(false)]
    public uint ID;
    public int MovieID;
    public int FileDataID;
}
