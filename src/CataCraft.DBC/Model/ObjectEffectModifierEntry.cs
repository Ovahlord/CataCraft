using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffectModifier.dbc")]
public sealed class ObjectEffectModifierEntry
{
    [Index(false)]
    public uint ID;
    public int InputType;
    public int MapType;
    public int OutputType;
    [Cardinality(4)]
    public float[] Param = new float[4];
}
