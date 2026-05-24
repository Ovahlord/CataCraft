using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NamesReserved.dbc")]
public sealed class NamesReservedEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Language;
}
