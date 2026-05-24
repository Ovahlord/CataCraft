using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GroundEffectDoodad.dbc")]
public sealed class GroundEffectDoodadEntry
{
    [Index(false)]
    public uint ID;
    public string Doodadpath = string.Empty;
    public int Flags;
}
