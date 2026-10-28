using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffect.dbc")]
public sealed class ObjectEffectEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int ObjectEffectGroupID;
    public int TriggerType;
    public int EventType;
    public int EffectRecType;
    public int EffectRecID;
    public int Attachment;
    [Cardinality(3)]
    public float[] Offset = new float[3];
    public int ObjectEffectModifierID;
}
