using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Package.dbc")]
public sealed class PackageEntry
{
    [Index(true)]
    public uint ID;
    public string Icon = string.Empty;
    public int Cost;
    public string Name = string.Empty;
}
