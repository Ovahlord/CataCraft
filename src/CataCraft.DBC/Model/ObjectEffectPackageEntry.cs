using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffectPackage.dbc")]
public sealed class ObjectEffectPackageEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
