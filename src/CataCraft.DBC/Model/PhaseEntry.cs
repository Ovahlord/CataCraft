using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Phase.dbc")]
public sealed class PhaseEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
}
