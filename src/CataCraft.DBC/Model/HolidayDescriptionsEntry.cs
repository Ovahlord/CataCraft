using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("HolidayDescriptions.dbc")]
public sealed class HolidayDescriptionsEntry
{
    [Index(true)]
    public uint ID;
    public string Description = string.Empty;
}
