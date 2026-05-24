using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LockType.dbc")]
public sealed class LockTypeEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public string ResourceName = string.Empty;
    public string Verb = string.Empty;
    public string CursorName = string.Empty;
}
