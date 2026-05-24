using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TerrainType.dbc")]
public sealed class TerrainTypeEntry
{
    [Index(false)]
    public uint ID;
    public int TerrainID;
    public string TerrainDesc = string.Empty;
    public int FootstepSprayRun;
    public int FootstepSprayWalk;
    public int SoundID;
    public int Flags;
}
