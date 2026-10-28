using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ResearchField.dbc")]
public sealed class ResearchFieldEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Slot;
}
