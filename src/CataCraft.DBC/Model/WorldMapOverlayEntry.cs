using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldMapOverlay.dbc")]
public sealed class WorldMapOverlayEntry
{
    [Index(false)]
    public uint ID;
    public int MapAreaID;
    [Cardinality(4)]
    public int[] AreaID = new int[4];
    public string TextureName = string.Empty;
    public int TextureWidth;
    public int TextureHeight;
    public int OffsetX;
    public int OffsetY;
    public int HitRectTop;
    public int HitRectLeft;
    public int HitRectBottom;
    public int HitRectRight;
}
