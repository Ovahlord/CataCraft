using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtNPCManaCostScaler.dbc")]
public sealed class gtNPCManaCostScalerEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
