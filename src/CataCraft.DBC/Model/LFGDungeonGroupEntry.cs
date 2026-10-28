using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LFGDungeonGroup.dbc")]
public sealed class LFGDungeonGroupEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int OrderIndex;
    public int ParentGroupID;
    public int TypeID;
}
