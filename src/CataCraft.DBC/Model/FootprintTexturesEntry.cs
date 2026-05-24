using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FootprintTextures.dbc")]
public sealed class FootprintTexturesEntry
{
    [Index(false)]
    public uint ID;
    public string FootstepFilename = string.Empty;
}
