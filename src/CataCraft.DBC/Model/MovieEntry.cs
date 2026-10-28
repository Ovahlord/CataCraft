using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Movie.dbc")]
public sealed class MovieEntry
{
    [Index(true)]
    public uint ID;
    public string Filename = string.Empty;
    public int Volume;
    public int KeyID;
}
