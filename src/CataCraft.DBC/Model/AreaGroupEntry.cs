using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AreaGroup.dbc")]
public sealed class AreaGroupEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(6)]
    public int[] AreaID = new int[6];
    public int NextAreaID;
}
