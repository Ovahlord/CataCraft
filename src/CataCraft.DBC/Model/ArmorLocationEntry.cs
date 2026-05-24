using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ArmorLocation.dbc")]
public sealed class ArmorLocationEntry
{
    [Index(false)]
    public uint ID;
    public float Clothmodifier;
    public float Leathermodifier;
    public float Chainmodifier;
    public float Platemodifier;
    public float Modifier;
}
