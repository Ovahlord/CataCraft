using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NumTalentsAtLevel.dbc")]
public sealed class NumTalentsAtLevelEntry
{
    public int Level;
    public float NumberOfTalents;
}
