using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisualEffectName.dbc")]
public sealed class SpellVisualEffectNameEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public string FileName = string.Empty;
    public float AreaEffectSize;
    public float Scale;
    public float MinAllowedScale;
    public float MaxAllowedScale;
    public int Type;
    public float Alpha;
}
