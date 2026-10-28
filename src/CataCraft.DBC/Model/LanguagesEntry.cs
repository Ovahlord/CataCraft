using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Languages.dbc")]
public sealed class LanguagesEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
}
