using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisual.dbc")]
public sealed class SpellVisualEntry
{
    [Index(false)]
    public uint ID;
    public int PrecastKit;
    public int CastKit;
    public int ImpactKit;
    public int StateKit;
    public int StateDoneKit;
    public int ChannelKit;
    public int HasMissile;
    public int MissileModel;
    public int MissilePathType;
    public int MissileDestinationAttachment;
    public int MissileSound;
    public int AnimEventSoundID;
    public int Flags;
    public int CasterImpactKit;
    public int TargetImpactKit;
    public int MissileAttachment;
    public int MissileFollowGroundHeight;
    public int MissileFollowGroundDropSpeed;
    public int MissileFollowGroundApproach;
    public int MissileFollowGroundFlags;
    public int MissileMotion;
    public int MissileTargetingKit;
    public int InstantAreaKit;
    public int ImpactAreaKit;
    public int PersistentAreaKit;
    [Cardinality(3)]
    public float[] MissileCastOffset = new float[3];
    [Cardinality(3)]
    public float[] MissileImpactOffset = new float[3];
    public int Unknown410;
}
