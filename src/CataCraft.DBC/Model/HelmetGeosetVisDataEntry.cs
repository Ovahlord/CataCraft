using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("HelmetGeosetVisData.dbc")]
public sealed class HelmetGeosetVisDataEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(7)]
    public int[] HideGeoset = new int[7];
}
