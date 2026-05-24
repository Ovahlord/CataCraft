using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("BattlemasterList.dbc")]
public sealed class BattlemasterListEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(8)]
    public int[] MapID = new int[8];
    public int InstanceType;
    public int GroupsAllowed;
    public string Name = string.Empty;
    public int MaxGroupSize;
    public int HolidayWorldState;
    public int MinLevel;
    public int MaxLevel;
    public int RatedPlayers;
    public int MinPlayers;
    public int MaxPlayers;
    public int Flags;
}
