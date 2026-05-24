using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellEffectCameraShakes.dbc")]
public sealed class SpellEffectCameraShakesEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(3)]
    public int[] CameraShake = new int[3];
}
