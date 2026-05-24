using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ChrClassesXPowerTypes.dbc")]
public sealed class ChrClassesXPowerTypesEntry
{
    [Index(false)]
    public uint ID;
    public int ClassID;
    public int PowerType;
}
