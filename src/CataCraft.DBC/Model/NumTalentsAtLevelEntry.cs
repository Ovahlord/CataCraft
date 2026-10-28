using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NumTalentsAtLevel.dbc")]
public sealed class NumTalentsAtLevelEntry
{
    [Index(true)]
    public int Level;
    public float NumberOfTalents;
}
