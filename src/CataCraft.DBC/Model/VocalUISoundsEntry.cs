using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("VocalUISounds.dbc")]
public sealed class VocalUISoundsEntry
{
    [Index(true)]
    public uint ID;
    public int VocalUIEnum;
    public int RaceID;
    [Cardinality(2)]
    public int[] NormalSoundID = new int[2];
    [Cardinality(2)]
    public int[] PissedSoundID = new int[2];
}
