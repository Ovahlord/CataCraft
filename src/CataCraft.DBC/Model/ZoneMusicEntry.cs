using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ZoneMusic.dbc")]
public sealed class ZoneMusicEntry
{
    [Index(false)]
    public uint ID;
    public string SetName = string.Empty;
    [Cardinality(2)]
    public int[] SilenceIntervalMin = new int[2];
    [Cardinality(2)]
    public int[] SilenceIntervalMax = new int[2];
    [Cardinality(2)]
    public int[] Sounds = new int[2];
}
