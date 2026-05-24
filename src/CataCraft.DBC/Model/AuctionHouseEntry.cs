using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AuctionHouse.dbc")]
public sealed class AuctionHouseEntry
{
    [Index(false)]
    public uint ID;
    public int FactionID;
    public int DepositRate;
    public int ConsignmentRate;
    public string Name = string.Empty;
}
