using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtRegenMPPerSpt.dbc")]
public sealed class gtRegenMPPerSptEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
