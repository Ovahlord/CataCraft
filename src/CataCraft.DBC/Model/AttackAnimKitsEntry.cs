using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("AttackAnimKits.dbc")]
public sealed class AttackAnimKitsEntry
{
    [Index(false)]
    public uint ID;
    public int ItemSubclassID;
    public int AnimTypeID;
    public int AnimFrequency;
    public int WhichHand;
}
