using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("FactionTemplate.dbc")]
public sealed class FactionTemplateEntry
{
    [Index(false)]
    public uint ID;
    public int Faction;
    public int Flags;
    public int FactionGroup;
    public int FriendGroup;
    public int EnemyGroup;
    [Cardinality(4)]
    public int[] Enemies = new int[4];
    [Cardinality(4)]
    public int[] Friend = new int[4];
}
