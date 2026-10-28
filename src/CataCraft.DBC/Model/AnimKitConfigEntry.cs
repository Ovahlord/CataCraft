using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AnimKitConfig.dbc")]
public sealed class AnimKitConfigEntry
{
    [Index(true)]
    public uint ID;
    public int ConfigFlags;
}
