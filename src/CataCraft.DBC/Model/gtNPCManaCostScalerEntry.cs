using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtNPCManaCostScaler.dbc")]
public sealed class gtNPCManaCostScalerEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
