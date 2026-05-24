using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ItemVisualEffects.dbc")]
public sealed class ItemVisualEffectsEntry
{
    [Index(false)]
    public uint ID;
    public string Model = string.Empty;
}
