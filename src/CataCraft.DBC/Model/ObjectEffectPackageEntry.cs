using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffectPackage.dbc")]
public sealed class ObjectEffectPackageEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
