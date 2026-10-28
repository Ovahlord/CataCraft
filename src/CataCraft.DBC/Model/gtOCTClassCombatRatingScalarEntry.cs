using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTClassCombatRatingScalar.dbc")]
public sealed class gtOCTClassCombatRatingScalarEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
