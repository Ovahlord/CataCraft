using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GuildPerkSpells.dbc")]
public sealed class GuildPerkSpellsEntry
{
    [Index(true)]
    public uint ID;
    public int GuildLevel;
    public int SpellID;
}
