using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("JournalEncounterSection.dbc")]
public sealed class JournalEncounterSectionEntry
{
    [Index(true)]
    public uint ID;
    public int JournalEncounterID;
    public int NextSiblingSectionID;
    public int FirstChildSectionID;
    public int ParentSectionID;
    public int OrderIndex;
    public int Type;
    public int Flags;
    public int IconFlags;
    public string Title = string.Empty;
    public string BodyText = string.Empty;
    public int DifficultyMask;
    public int IconCreatureDisplayInfoID;
    public int IconFileDataID;
}
