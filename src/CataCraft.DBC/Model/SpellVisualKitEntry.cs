using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellVisualKit.dbc")]
public sealed class SpellVisualKitEntry
{
    [Index(false)]
    public uint ID;
    public int StartAnimID;
    public int AnimID;
    public int AnimKitID;
    public int HeadEffect;
    public int ChestEffect;
    public int BaseEffect;
    public int LeftHandEffect;
    public int RightHandEffect;
    public int BreathEffect;
    public int LeftWeaponEffect;
    public int RightWeaponEffect;
    [Cardinality(3)]
    public int[] SpecialEffect = new int[3];
    public int WorldEffect;
    public int SoundID;
    public int ShakeID;
    [Cardinality(4)]
    public int[] CharProc = new int[4];
    [Cardinality(4)]
    public float[] CharParamZero = new float[4];
    [Cardinality(4)]
    public float[] CharParamOne = new float[4];
    [Cardinality(4)]
    public float[] CharParamTwo = new float[4];
    [Cardinality(4)]
    public float[] CharParamThree = new float[4];
    public int Flags;
}
