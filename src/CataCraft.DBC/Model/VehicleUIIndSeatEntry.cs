using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("VehicleUIIndSeat.dbc")]
public sealed class VehicleUIIndSeatEntry
{
    [Index(true)]
    public uint ID;
    public int VehicleUIIndicatorID;
    public int VirtualSeatIndex;
    public float XPos;
    public float YPos;
}
