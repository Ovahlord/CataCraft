using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NameGen.dbc")]
public sealed class NameGenEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int RaceID;
    public int Sex;
}
