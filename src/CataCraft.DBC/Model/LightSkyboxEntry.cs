using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LightSkybox.dbc")]
public sealed class LightSkyboxEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
}
