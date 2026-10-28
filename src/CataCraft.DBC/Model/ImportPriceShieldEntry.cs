using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ImportPriceShield.dbc")]
public sealed class ImportPriceShieldEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
