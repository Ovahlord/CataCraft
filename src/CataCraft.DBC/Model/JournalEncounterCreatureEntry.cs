using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("JournalEncounterCreature.dbc")]
public sealed class JournalEncounterCreatureEntry
{
    [Index(true)]
    public uint ID;
    public int JournalEncounterID;
    public int CreatureDisplayInfoID;
    public int OrderIndex;
    public int FileDataID;
    public string Name = string.Empty;
    public string Description = string.Empty;
}
