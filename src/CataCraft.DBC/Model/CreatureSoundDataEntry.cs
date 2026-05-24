using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("CreatureSoundData.dbc")]
public sealed class CreatureSoundDataEntry
{
    [Index(false)]
    public uint ID;
    public int SoundExertionID;
    public int SoundExertionCriticalID;
    public int SoundInjuryID;
    public int SoundInjuryCriticalID;
    public int SoundInjuryCrushingBlowID;
    public int SoundDeathID;
    public int SoundStunID;
    public int SoundStandID;
    public int SoundFootstepID;
    public int SoundAggroID;
    public int SoundWingFlapID;
    public int SoundWingGlideID;
    public int SoundAlertID;
    [Cardinality(5)]
    public int[] SoundFidget = new int[5];
    [Cardinality(4)]
    public int[] CustomAttack = new int[4];
    public int NPCSoundID;
    public int LoopSoundID;
    public int CreatureImpactType;
    public int SoundJumpStartID;
    public int SoundJumpEndID;
    public int SoundPetAttackID;
    public int SoundPetOrderID;
    public int SoundPetDismissID;
    public float FidgetDelaySecondsMin;
    public float FidgetDelaySecondsMax;
    public int BirthSoundID;
    public int SpellCastDirectedSoundID;
    public int SubmergeSoundID;
    public int SubmergedSoundID;
    public int CreatureSoundDataIDPet;
    public int TransformSoundID;
    public int TransformAnimatedSoundID;
}
