using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtSpellScaling.dbc")]
public sealed class gtSpellScalingEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
