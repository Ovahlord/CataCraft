using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundFilterElem.dbc")]
public sealed class SoundFilterElemEntry
{
    [Index(true)]
    public uint ID;
    public int SoundFilterID;
    public int OrderIndex;
    public int FilterType;
    [Cardinality(9)]
    public float[] Params = new float[9];
}
