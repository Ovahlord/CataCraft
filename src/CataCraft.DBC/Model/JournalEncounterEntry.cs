using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("JournalEncounter.dbc")]
public sealed class JournalEncounterEntry
{
    [Index(false)]
    public uint ID;
    public int DungeonMapID;
    public int WorldMapAreaID;
    [Cardinality(2)]
    public float[] Map = new float[2];
    public int FirstSectionID;
    public int JournalInstanceID;
    public int OrderIndex;
    public int DifficultyMask;
    public string Name = string.Empty;
    public string Description = string.Empty;
}
