using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SkillTiers.dbc")]
public sealed class SkillTiersEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(16)]
    public int[] Cost = new int[16];
    [Cardinality(16)]
    public int[] Value = new int[16];
}
