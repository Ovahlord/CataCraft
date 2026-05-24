using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("gtCombatRatings.dbc")]
public sealed class gtCombatRatingsEntry
{
    [Index(false)]
    public uint ID;
    public float Data;
}
