using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffectGroup.dbc")]
public sealed class ObjectEffectGroupEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
