using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellFocusObject.dbc")]
public sealed class SpellFocusObjectEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
