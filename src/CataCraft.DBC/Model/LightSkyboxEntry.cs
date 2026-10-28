using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LightSkybox.dbc")]
public sealed class LightSkyboxEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
}
