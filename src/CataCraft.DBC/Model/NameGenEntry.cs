using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NameGen.dbc")]
public sealed class NameGenEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int RaceID;
    public int Sex;
}
