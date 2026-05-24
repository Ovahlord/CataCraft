using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TaxiPath.dbc")]
public sealed class TaxiPathEntry
{
    [Index(false)]
    public uint ID;
    public int FromTaxiNode;
    public int ToTaxiNode;
    public int Cost;
}
