using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellFlyout.dbc")]
public sealed class SpellFlyoutEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public int RaceMask;
    public int ClassMask;
    public int SpellIconID;
    public string Name = string.Empty;
    public string Description = string.Empty;
}
