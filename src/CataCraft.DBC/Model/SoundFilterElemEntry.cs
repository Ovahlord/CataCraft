using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundFilterElem.dbc")]
public sealed class SoundFilterElemEntry
{
    [Index(false)]
    public uint ID;
    public int SoundFilterID;
    public int OrderIndex;
    public int FilterType;
    [Cardinality(9)]
    public float[] Params = new float[9];
}
