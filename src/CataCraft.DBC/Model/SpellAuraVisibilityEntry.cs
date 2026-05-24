using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellAuraVisibility.dbc")]
public sealed class SpellAuraVisibilityEntry
{
    [Index(false)]
    public uint ID;
    public int SpellID;
    public int Type;
    public int Flags;
}
