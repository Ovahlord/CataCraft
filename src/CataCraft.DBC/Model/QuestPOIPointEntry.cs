using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestPOIPoint.dbc")]
public sealed class QuestPOIPointEntry
{
    [Index(true)]
    public uint ID;
    public int X;
    public int Y;
    public int QuestPOIBlobID;
}
