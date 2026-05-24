using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Phase.dbc")]
public sealed class PhaseEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
}
