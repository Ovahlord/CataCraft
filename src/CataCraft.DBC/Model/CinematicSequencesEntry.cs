using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CinematicSequences.dbc")]
public sealed class CinematicSequencesEntry
{
    [Index(true)]
    public uint ID;
    public int SoundID;
    [Cardinality(8)]
    public int[] Camera = new int[8];
}
