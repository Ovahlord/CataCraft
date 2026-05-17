using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestInfo.dbc")]
public sealed class QuestInfoEntry
{
    [Index(true)]
    public uint ID;
    public string InfoName = string.Empty;
}
