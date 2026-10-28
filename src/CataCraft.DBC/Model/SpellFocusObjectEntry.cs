using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellFocusObject.dbc")]
public sealed class SpellFocusObjectEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
