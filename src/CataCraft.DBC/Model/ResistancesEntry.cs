using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Resistances.dbc")]
public sealed class ResistancesEntry
{
    [Index(true)]
    public uint ID;
    public int Flags;
    public int FizzleSoundID;
    public string Name = string.Empty;
}
