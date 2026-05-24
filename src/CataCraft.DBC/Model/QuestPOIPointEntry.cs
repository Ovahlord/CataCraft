using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestPOIPoint.dbc")]
public sealed class QuestPOIPointEntry
{
    [Index(false)]
    public uint ID;
    public int X;
    public int Y;
    public int QuestPOIBlobID;
}
