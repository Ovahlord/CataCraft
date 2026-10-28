using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MovieVariation.dbc")]
public sealed class MovieVariationEntry
{
    [Index(true)]
    public uint ID;
    public int MovieID;
    public int FileDataID;
}
