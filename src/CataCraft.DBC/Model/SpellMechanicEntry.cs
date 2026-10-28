using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellMechanic.dbc")]
public sealed class SpellMechanicEntry
{
    [Index(true)]
    public uint ID;
    public string StateName = string.Empty;
}
