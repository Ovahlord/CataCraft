using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("VehicleUIIndSeat.dbc")]
public sealed class VehicleUIIndSeatEntry
{
    [Index(false)]
    public uint ID;
    public int VehicleUIIndicatorID;
    public int VirtualSeatIndex;
    public float XPos;
    public float YPos;
}
