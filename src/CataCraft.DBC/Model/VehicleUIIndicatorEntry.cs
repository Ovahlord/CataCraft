using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("VehicleUIIndicator.dbc")]
public sealed class VehicleUIIndicatorEntry
{
    [Index(true)]
    public uint ID;
    public string BackgroundTexture = string.Empty;
}
