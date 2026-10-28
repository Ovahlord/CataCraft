using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundFilter.dbc")]
public sealed class SoundFilterEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
