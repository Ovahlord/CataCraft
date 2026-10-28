using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffectModifier.dbc")]
public sealed class ObjectEffectModifierEntry
{
    [Index(true)]
    public uint ID;
    public int InputType;
    public int MapType;
    public int OutputType;
    [Cardinality(4)]
    public float[] Param = new float[4];
}
