using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureMovementInfo.dbc")]
public sealed class CreatureMovementInfoEntry
{
    [Index(true)]
    public uint ID;
    public float SmoothFacingChaseRate;
}
