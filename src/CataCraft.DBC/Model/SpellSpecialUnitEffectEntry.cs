using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellSpecialUnitEffect.dbc")]
public sealed class SpellSpecialUnitEffectEntry
{
    [Index(false)]
    public uint EnumID;
    public int SpellVisualEffectNameID;
}
