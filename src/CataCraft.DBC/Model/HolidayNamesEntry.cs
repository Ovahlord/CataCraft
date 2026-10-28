using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("HolidayNames.dbc")]
public sealed class HolidayNamesEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
