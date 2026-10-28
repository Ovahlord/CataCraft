using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("JournalEncounterItem.dbc")]
public sealed class JournalEncounterItemEntry
{
    [Index(true)]
    public uint ID;
    public int JournalEncounterID;
    public int ItemID;
    public int DifficultyMask;
    public int FactionMask;
}
