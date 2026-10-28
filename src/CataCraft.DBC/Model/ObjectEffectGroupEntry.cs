using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffectGroup.dbc")]
public sealed class ObjectEffectGroupEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
