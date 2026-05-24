using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("TransportRotation.dbc")]
public sealed class TransportRotationEntry
{
    [Index(false)]
    public uint ID;
    public int GameObjectsID;
    public int TimeIndex;
    [Cardinality(4)]
    public float[] Rot = new float[4];
}
