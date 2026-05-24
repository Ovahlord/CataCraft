using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Movie.dbc")]
public sealed class MovieEntry
{
    [Index(false)]
    public uint ID;
    public string Filename = string.Empty;
    public int Volume;
    public int KeyID;
}
