using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellItemEnchantmentCondition.dbc")]
public sealed class SpellItemEnchantmentConditionEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(5)]
    public sbyte[] LtOperandType = new sbyte[5];
    [Cardinality(3)]
    public sbyte[] Padding60118179002 = new sbyte[3];
    [Cardinality(5)]
    public int[] LtOperand = new int[5];
    [Cardinality(5)]
    public sbyte[] Operator = new sbyte[5];
    [Cardinality(5)]
    public sbyte[] RtOperandType = new sbyte[5];
    [Cardinality(2)]
    public sbyte[] Padding60118179006 = new sbyte[2];
    [Cardinality(5)]
    public int[] RtOperand = new int[5];
    [Cardinality(5)]
    public sbyte[] Logic = new sbyte[5];
    [Cardinality(3)]
    public sbyte[] Padding60118179009 = new sbyte[3];
}
