using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellDescriptionVariables.dbc")]
public sealed class SpellDescriptionVariablesEntry
{
    [Index(false)]
    public uint ID;
    public string Variables = string.Empty;
}
