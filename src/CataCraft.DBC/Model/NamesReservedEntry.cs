using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NamesReserved.dbc")]
public sealed class NamesReservedEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Language;
}
