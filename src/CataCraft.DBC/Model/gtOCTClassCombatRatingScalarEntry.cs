using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTClassCombatRatingScalar.dbc")]
public sealed class gtOCTClassCombatRatingScalarEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
