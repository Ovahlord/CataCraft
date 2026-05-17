using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LiquidMaterial.dbc")]
public sealed class LiquidMaterialEntry
{
    [Index(true)]
    public uint ID;
    public int LVF;
    public int Flags;
}
