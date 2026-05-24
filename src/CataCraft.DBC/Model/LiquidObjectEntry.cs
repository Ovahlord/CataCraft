using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LiquidObject.dbc")]
public sealed class LiquidObjectEntry
{
    [Index(false)]
    public uint ID;
    public float FlowDirection;
    public float FlowSpeed;
    public int LiquidTypeID;
    public int Fishable;
    public int Reflection;
}
