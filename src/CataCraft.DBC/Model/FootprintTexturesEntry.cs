using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FootprintTextures.dbc")]
public sealed class FootprintTexturesEntry
{
    [Index(true)]
    public uint ID;
    public string FootstepFilename = string.Empty;
}
