using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemVisualEffects.dbc")]
public sealed class ItemVisualEffectsEntry
{
    [Index(true)]
    public uint ID;
    public string Model = string.Empty;
}
