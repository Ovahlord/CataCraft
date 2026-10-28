using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtOCTHpPerStamina.dbc")]
public sealed class gtOCTHpPerStaminaEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
