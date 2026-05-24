using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ImportPriceShield.dbc")]
public sealed class ImportPriceShieldEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
