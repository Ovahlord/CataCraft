using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundAmbience.dbc")]
public sealed class SoundAmbienceEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(2)]
    public int[] AmbienceID = new int[2];
}
