using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestSort.dbc")]
public sealed class QuestSortEntry
{
    [Index(true)]
    public uint ID;
    public string SortName = string.Empty;
}
