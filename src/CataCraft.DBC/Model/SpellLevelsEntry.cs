using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellLevels.dbc")]
public sealed class SpellLevelsEntry
{
    [Index(false)]
    public uint ID;
    public int BaseLevel;
    public int MaxLevel;
    public int SpellLevel;
}
