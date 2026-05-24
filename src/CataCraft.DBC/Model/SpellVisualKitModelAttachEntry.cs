using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisualKitModelAttach.dbc")]
public sealed class SpellVisualKitModelAttachEntry
{
    [Index(false)]
    public uint ID;
    public int ParentSpellVisualKitID;
    public int SpellVisualEffectNameID;
    public int AttachmentID;
    [Cardinality(3)]
    public float[] Offset = new float[3];
    public float Yaw;
    public float Pitch;
    public float Roll;
    public int Unknown406;
    public int StartAnimID;
    public int AnimID;
    public int EndAnimID;
}
