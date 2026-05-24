using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellMechanic.dbc")]
public sealed class SpellMechanicEntry
{
    [Index(false)]
    public uint ID;
    public string StateName = string.Empty;
}
