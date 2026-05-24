using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTHpPerStamina.dbc")]
public sealed class gtOCTHpPerStaminaEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
