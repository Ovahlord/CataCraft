using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CinematicSequences.dbc")]
public sealed class CinematicSequencesEntry
{
    [Index(false)]
    public uint ID;
    public int SoundID;
    [Cardinality(8)]
    public int[] Camera = new int[8];
}
