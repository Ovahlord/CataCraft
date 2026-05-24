using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ImportPriceArmor.dbc")]
public sealed class ImportPriceArmorEntry
{
    [Index(false)]
    public uint ID;
    public float ClothModifier;
    public float LeatherModifier;
    public float ChainModifier;
    public float PlateModifier;
}
