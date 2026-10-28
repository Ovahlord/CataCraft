using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaGroup.dbc")]
public sealed class AreaGroupEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(6)]
    public int[] AreaID = new int[6];
    public int NextAreaID;
}
