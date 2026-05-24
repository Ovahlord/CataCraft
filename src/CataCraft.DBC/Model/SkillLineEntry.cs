using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillLine.dbc")]
public sealed class SkillLineEntry
{
    [Index(false)]
    public uint ID;
    public int CategoryID;
    public string DisplayName = string.Empty;
    public string Description = string.Empty;
    public int SpellIconID;
    public string AlternateVerb = string.Empty;
    public int CanLink;
}
