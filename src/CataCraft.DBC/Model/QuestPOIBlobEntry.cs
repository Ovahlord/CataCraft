using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("QuestPOIBlob.dbc")]
public sealed class QuestPOIBlobEntry
{
    [Index(false)]
    public uint ID;
    public int NumPoints;
    public int MapID;
    public int WorldMapAreaID;
}
