using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AttackAnimKits.dbc")]
public sealed class AttackAnimKitsEntry
{
    [Index(true)]
    public uint ID;
    public int ItemSubclassID;
    public int AnimTypeID;
    public int AnimFrequency;
    public int WhichHand;
}
