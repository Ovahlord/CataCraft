using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ObjectEffectPackageElem.dbc")]
public sealed class ObjectEffectPackageElemEntry
{
    [Index(true)]
    public uint ID;
    public int ObjectEffectPackageID;
    public int ObjectEffectGroupID;
    public int StateType;
}
