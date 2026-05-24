using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemArmorQuality.dbc")]
public sealed class ItemArmorQualityEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(7)]
    public float[] Qualitymod = new float[7];
    public int ItemLevel;
}
