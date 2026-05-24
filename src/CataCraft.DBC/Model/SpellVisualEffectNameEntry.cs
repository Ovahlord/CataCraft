using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisualEffectName.dbc")]
public sealed class SpellVisualEffectNameEntry
{
    [Index(false)]
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
