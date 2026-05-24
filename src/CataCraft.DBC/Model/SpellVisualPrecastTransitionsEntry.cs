using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisualPrecastTransitions.dbc")]
public sealed class SpellVisualPrecastTransitionsEntry
{
    [Index(false)]
    public uint ID;
    public string PrecastLoadAnimName = string.Empty;
    public string PrecastHoldAnimName = string.Empty;
}
