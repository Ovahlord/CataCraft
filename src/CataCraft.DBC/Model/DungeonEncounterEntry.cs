using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DungeonEncounter.dbc")]
public sealed class DungeonEncounterEntry
{
    [Index(true)]
    public uint ID;
    public int MapID;
    public int Difficulty;
    public int OrderIndex;
    public int Bit;
    public string Name = string.Empty;
    public int CreatureDisplayID;
    public int SpellIconID;
}
