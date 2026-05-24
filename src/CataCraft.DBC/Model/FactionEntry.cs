using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Faction.dbc")]
public sealed class FactionEntry
{
    [Index(false)]
    public uint ID;
    public int ReputationIndex;
    [Cardinality(4)]
    public int[] ReputationRaceMask = new int[4];
    [Cardinality(4)]
    public int[] ReputationClassMask = new int[4];
    [Cardinality(4)]
    public int[] ReputationBase = new int[4];
    [Cardinality(4)]
    public int[] ReputationFlags = new int[4];
    public int ParentFactionID;
    [Cardinality(2)]
    public float[] ParentFactionMod = new float[2];
    [Cardinality(2)]
    public int[] ParentFactionCap = new int[2];
    public string Name = string.Empty;
    public string Description = string.Empty;
    public int Expansion;
}
