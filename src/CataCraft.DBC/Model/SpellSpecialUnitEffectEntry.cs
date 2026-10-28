using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellSpecialUnitEffect.dbc")]
public sealed class SpellSpecialUnitEffectEntry
{
    [Index(true)]
    public uint EnumID;
    public int SpellVisualEffectNameID;
}
