using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("JournalEncounterItem.dbc")]
public sealed class JournalEncounterItemEntry
{
    [Index(false)]
    public uint ID;
    public int JournalEncounterID;
    public int ItemID;
    public int DifficultyMask;
    public int FactionMask;
}
