using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellMissileMotion.dbc")]
public sealed class SpellMissileMotionEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public string ScriptBody = string.Empty;
    public int Flags;
    public int MissileCount;
}
