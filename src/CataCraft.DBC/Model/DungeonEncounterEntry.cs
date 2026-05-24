using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DungeonEncounter.dbc")]
public sealed class DungeonEncounterEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    public int Difficulty;
    public int OrderIndex;
    public int Bit;
    public string Name = string.Empty;
    public int CreatureDisplayID;
    public int SpellIconID;
}
