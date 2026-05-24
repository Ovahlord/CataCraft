using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisualKitAreaModel.dbc")]
public sealed class SpellVisualKitAreaModelEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Flags;
    public int LifeTime;
    public float EmissionRate;
    public float Spacing;
    public float ModelScale;
}
