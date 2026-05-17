using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundFilter.dbc")]
public sealed class SoundFilterEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
