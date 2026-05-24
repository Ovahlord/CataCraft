using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TerrainMaterial.dbc")]
public sealed class TerrainMaterialEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Shader;
    public string EnvMapPath = string.Empty;
}
