using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Holidays.dbc")]
public sealed class HolidaysEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(10)]
    public int[] Duration = new int[10];
    [Cardinality(26)]
    public int[] Date = new int[26];
    public int Region;
    public int Looping;
    [Cardinality(10)]
    public int[] CalendarFlags = new int[10];
    public int HolidayNameID;
    public int HolidayDescriptionID;
    public string TextureFileName = string.Empty;
    public int Priority;
    public int CalendarFilterType;
    public int Flags;
}
