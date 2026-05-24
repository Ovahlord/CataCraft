using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LFGDungeonGroup.dbc")]
public sealed class LFGDungeonGroupEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int OrderIndex;
    public int ParentGroupID;
    public int TypeID;
}
