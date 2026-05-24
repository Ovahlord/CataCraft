using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ResearchField.dbc")]
public sealed class ResearchFieldEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Slot;
}
