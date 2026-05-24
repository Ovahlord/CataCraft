using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GuildPerkSpells.dbc")]
public sealed class GuildPerkSpellsEntry
{
    [Index(false)]
    public uint ID;
    public int GuildLevel;
    public int SpellID;
}
