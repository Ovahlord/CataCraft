using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisualPrecastTransitions.dbc")]
public sealed class SpellVisualPrecastTransitionsEntry
{
    [Index(true)]
    public uint ID;
    public string PrecastLoadAnimName = string.Empty;
    public string PrecastHoldAnimName = string.Empty;
}
