using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemDisenchantLoot.dbc")]
public sealed class ItemDisenchantLootEntry
{
    [Index(false)]
    public uint ID;
    public int Class;
    public int Subclass;
    public int Quality;
    public int MinLevel;
    public int MaxLevel;
    public int SkillRequired;
}
