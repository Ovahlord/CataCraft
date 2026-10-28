using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DanceMoves.dbc")]
public sealed class DanceMovesEntry
{
    [Index(true)]
    public uint ID;
    public int Type;
    public int Param;
    public int Fallback;
    public int Racemask;
    public string InternalName = string.Empty;
    public string Name = string.Empty;
    public int LockID;
}
