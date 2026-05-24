using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CastableRaidBuffs.dbc")]
public sealed class CastableRaidBuffsEntry
{
    [Index(false)]
    public uint ID;
    public int SpellID;
    public int CastingSpellID;
}
