using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureType.dbc")]
public sealed class CreatureTypeEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
}
