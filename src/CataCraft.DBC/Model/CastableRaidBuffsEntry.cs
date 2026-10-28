using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CastableRaidBuffs.dbc")]
public sealed class CastableRaidBuffsEntry
{
    [Index(true)]
    public uint ID;
    public int SpellID;
    public int CastingSpellID;
}
