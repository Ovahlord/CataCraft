using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Languages.dbc")]
public sealed class LanguagesEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
}
