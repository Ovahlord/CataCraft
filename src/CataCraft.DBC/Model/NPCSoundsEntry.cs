using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("NPCSounds.dbc")]
public sealed class NPCSoundsEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(4)]
    public int[] SoundID = new int[4];
}
