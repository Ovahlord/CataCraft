using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtCombatRatings.dbc")]
public sealed class gtCombatRatingsEntry
{
    [Index(true)]
    public uint ID;
    public float Data;
}
