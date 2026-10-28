using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellInterrupts.dbc")]
public sealed class SpellInterruptsEntry
{
    [Index(true)]
    public uint ID;
    [Cardinality(2)]
    public int[] AuraInterruptFlags = new int[2];
    [Cardinality(2)]
    public int[] ChannelInterruptFlags = new int[2];
    public int InterruptFlags;
}
