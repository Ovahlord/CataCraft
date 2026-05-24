using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ScalingStatValues.dbc")]
public sealed class ScalingStatValuesEntry
{
    [Index(false)]
    public uint ID;
    public int Charlevel;
    public int Unknown400_0;
    public int Unknown400_1;
    public int Unknown400_2;
    public int Unknown400_3;
    public int Unknown400_4;
    public int Unknown400_5;
    public int Unknown400_6;
    public int Unknown400_7;
    public int Unknown400_8;
    public int Unknown400_9;
    public int Unknown400_10;
    public int Unknown400_11;
    [Cardinality(4)]
    public int[] ArmorShoulder = new int[4];
    [Cardinality(4)]
    public int[] ArmorChest = new int[4];
    [Cardinality(4)]
    public int[] ArmorHead = new int[4];
    [Cardinality(4)]
    public int[] ArmorLegs = new int[4];
    [Cardinality(4)]
    public int[] ArmorFeet = new int[4];
    [Cardinality(4)]
    public int[] ArmorWaist = new int[4];
    [Cardinality(4)]
    public int[] ArmorHands = new int[4];
    [Cardinality(4)]
    public int[] ArmorWrists = new int[4];
    public int Unknown400_12;
}
