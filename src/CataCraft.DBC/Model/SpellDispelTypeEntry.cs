using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellDispelType.dbc")]
public sealed class SpellDispelTypeEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public int Mask;
    public int ImmunityPossible;
    public string InternalName = string.Empty;
}
