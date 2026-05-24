using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("HolidayNames.dbc")]
public sealed class HolidayNamesEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
