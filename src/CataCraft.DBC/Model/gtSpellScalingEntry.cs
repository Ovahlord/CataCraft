using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtSpellScaling.dbc")]
public sealed class gtSpellScalingEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
