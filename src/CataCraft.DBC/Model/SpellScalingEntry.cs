using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellScaling.dbc")]
public sealed class SpellScalingEntry
{
    [Index(false)]
    public uint ID;
    public int CastTimeMin;
    public int CastTimeMax;
    public int CastTimeMaxLevel;
    public int Class;
    [Cardinality(3)]
    public float[] Coefficient = new float[3];
    [Cardinality(3)]
    public float[] Variance = new float[3];
    [Cardinality(3)]
    public float[] ComboPointsCoefficient = new float[3];
    public float NerfFactor;
    public int NerfMaxLevel;
}
