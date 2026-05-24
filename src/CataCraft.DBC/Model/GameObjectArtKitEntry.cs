using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("GameObjectArtKit.dbc")]
public sealed class GameObjectArtKitEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(3)]
    public string[] TextureVariation = new string[3];
    [Cardinality(4)]
    public string[] AttachModel = new string[4];
}
