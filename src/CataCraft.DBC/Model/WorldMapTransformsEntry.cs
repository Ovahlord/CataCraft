using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("WorldMapTransforms.dbc")]
public sealed class WorldMapTransformsEntry
{
    [Index(false)]
    public uint ID;
    public int MapID;
    [Cardinality(2)]
    public float[] RegionMin = new float[2];
    [Cardinality(2)]
    public float[] RegionMax = new float[2];
    public int NewMapID;
    [Cardinality(2)]
    public float[] RegionOffset = new float[2];
    public int NewDungeonMapID;
    public int Flags;
    public int NewAreaID;
}
