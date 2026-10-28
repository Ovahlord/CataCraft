using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureMovementInfo.dbc")]
public sealed class CreatureMovementInfoEntry
{
    [Index(true)]
    public uint ID;
    public float SmoothFacingChaseRate;
}
