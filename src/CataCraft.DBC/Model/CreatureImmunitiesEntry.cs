using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureImmunities.dbc")]
public sealed class CreatureImmunitiesEntry
{
    [Index(false)]
    public uint ID;
    public int School;
    public int DispelType;
    public int MechanicsAllowed;
    public int Mechanic;
    public int EffectsAllowed;
    [Cardinality(6)]
    public int[] Effect = new int[6];
    public int StatesAllowed;
    [Cardinality(12)]
    public int[] State = new int[12];
    public int Flags;
}
